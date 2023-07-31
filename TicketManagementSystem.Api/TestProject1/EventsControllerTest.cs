using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TicketManagementSystem.Api.Controllers;

using TicketManagementSystem.Api.Models;
using TicketManagementSystem.Api.Models.Dto;
using TicketManagementSystem.Api.Repositories;

namespace TMS.UnitTests
{
    [TestClass]
    public class EventsControllerTest
    {
        Mock<IEventRepository> _eventRepositoryMock;
       // Mock<IEventTypeRepository> _eventTypeMoq;
        Mock<IMapper> _mapperMoq;
        Mock<ILogger> _loggerMoq;
        List<Event> _moqList;
        List<EventDto> _dtoMoq;

        [TestInitialize]
        public void SetupMoqData()
        {
            _eventRepositoryMock = new Mock<IEventRepository>();
            //_eventTypeMoq = new Mock<IEventTypeRepository>();
            _mapperMoq = new Mock<IMapper>();
            _moqList = new List<Event>
            {
                new Event {EventId = 1,
                    Name = "Moq name",
                    Description = "Moq description",
                    EndDate = System.DateTime.Now,
                    StartDate = System.DateTime.Now,
                    EventType = new EventType {EventTypeId = 1,Name="test event type"},
                    EventTypeId = 1,
                    Venue = new Venue {VenueId = 1,Capacity = 12, Location = "Mock location",Type = "mock type"},
                    VenueId = 1
                }
            };
            _dtoMoq = new List<EventDto>
            {
                new EventDto
                {
                    //EndDate = System.DateTime.Now,
                    Description = "Moq description",
                    EventId = 1,
                    Name = "Moq name",
                    EventType = new EventType {EventTypeId = 1,Name="test event type"}.Name,
                    //StartDate = DateTime.Now,
                    Venue = new Venue {VenueId = 1,Capacity = 12, Location = "Mock location",Type = "mock type"}.Location
                }
            };
        }

        [TestMethod]
        public async Task GetAllEventsReturnListOfEvents()
        {
            //Arrange

            IEnumerable<Event> moqEvents = _moqList;
            Task<IEnumerable<Event>> moqTask = Task.Run(() => moqEvents);
            _eventRepositoryMock.Setup(moq => moq.GetAll()).Returns((Task<IEnumerable<Event>>)moqTask);

            _mapperMoq.Setup(moq => moq.Map<IEnumerable<EventDto>>(It.IsAny<IReadOnlyList<Event>>())).Returns(_dtoMoq);

            var controller = new EventController(_eventRepositoryMock.Object, _mapperMoq.Object, (ILogger<EventController>)_loggerMoq.Object);

            //Act
            var events = await controller .GetAll();
            var eventResult = events.Result as OkObjectResult;
            var eventCount = eventResult.Value as IList;

            //Assert

            Assert.AreEqual(_moqList.Count, eventCount.Count);
        }

        [TestMethod]
        public async Task GetEventByIdReturnNotFoundWhenNoRecordFound()
        {
            //Arrange
            _eventRepositoryMock.Setup(moq => moq.GetById(It.IsAny<int>())).Returns(Task.Run(() => _moqList.First()));
            _mapperMoq.Setup(moq => moq.Map<IEnumerable<EventDto>>(It.IsAny<IReadOnlyList<Event>>())).Returns((IEnumerable<EventDto>)null);
            var controller = new EventController(_eventRepositoryMock.Object, _mapperMoq.Object, (ILogger<EventController>)_loggerMoq.Object);
            //Act

            var result = await controller.GetById(1);
            var eventResult = result.Result as NotFoundResult;


            //Assert

            Assert.IsTrue(eventResult.StatusCode == 404);
        }

        [TestMethod]
        public async Task GetEventByIdReturnFirstRecord()
        {
            //Arrange
            _eventRepositoryMock.Setup(moq => moq.GetById(It.IsAny<int>())).Returns(Task.Run(() => _moqList.First()));
            _mapperMoq.Setup(moq => moq.Map<EventDto>(It.IsAny<Event>())).Returns(_dtoMoq.First());
            var controller = new EventController(_eventRepositoryMock.Object, _mapperMoq.Object, (ILogger<EventController>)_loggerMoq.Object);
            //Act

            var result = await controller.GetById(1);
            var eventResult = result.Result as OkObjectResult;
            var eventCount = eventResult.Value as EventDto;

            //Assert

            Assert.IsFalse(string.IsNullOrEmpty(eventCount.Name));
            Assert.AreEqual(1, eventCount.EventId);
        }

        [TestMethod]
        public async Task GetEventByIDThrowsAnException()
        {
            //Arrange
            _eventRepositoryMock.Setup(moq => moq.GetById(It.IsAny<int>())).Throws<Exception>();
            _mapperMoq.Setup(moq => moq.Map<EventDto>(It.IsAny<Event>())).Returns(_dtoMoq.First());
            var controller = new EventController(_eventRepositoryMock.Object, _mapperMoq.Object, (ILogger<EventController>)_loggerMoq.Object);
            //Act

            var result = await controller.GetById(1);

            //Assert

            Assert.IsNull(result);
        }
    }
}
