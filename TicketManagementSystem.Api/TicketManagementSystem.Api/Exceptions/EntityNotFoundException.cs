using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagementSystem.Api.Exceptions
{
    public class EntityNotFoundException : Exception
    {

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string errorMessage) : base(errorMessage)
        {
        }

        public EntityNotFoundException(string errorMessage, Exception innerException) : base(errorMessage, innerException)
        {
        }

        public EntityNotFoundException(int id, string entityName) :  base(FormattableString.Invariant($"'{entityName}' with id '{id}' was not found."))
        {
        }

    }
}
