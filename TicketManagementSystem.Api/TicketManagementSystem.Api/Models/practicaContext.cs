using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TicketManagementSystem.Api.Models
{
    public partial class practicaContext : DbContext
    {
        public practicaContext()
        {
        }

        public practicaContext(DbContextOptions<practicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Orderr> Orderrs { get; set; }
        public virtual DbSet<TicketCategory> TicketCategories { get; set; }
        public virtual DbSet<TotalNumberOfTicketsPerCategory> TotalNumberOfTicketsPerCategories { get; set; }
        public virtual DbSet<Userr> Userrs { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-L0KD29U\\MSSQLSERVER01;Initial Catalog=practica;Persist Security Info=True;User ID=andreea;Password=12345;TrustServerCertificate=True;encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasPrecision(6)
                    .HasColumnName("end_date");

                entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StartDate)
                    .HasPrecision(6)
                    .HasColumnName("start_date");

                entity.Property(e => e.VenueId).HasColumnName("venue_id");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_event_type_id");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_venue_id");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("event_type");

                entity.HasIndex(e => e.Name, "UQ__event_ty__72E12F1BC9E0101D")
                    .IsUnique();

                entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Orderr>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__orderr__465962296CEC53DD");

                entity.ToTable("orderr");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.NumberOfTickets).HasColumnName("number_of_tickets");

                entity.Property(e => e.OrderedAt)
                    .HasPrecision(6)
                    .HasColumnName("ordered_at");

                entity.Property(e => e.TicketCategoryId).HasColumnName("ticket_category_id");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.TicketCategory)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.TicketCategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ticket_category_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_user_id");
            });

            modelBuilder.Entity<TicketCategory>(entity =>
            {
                entity.ToTable("ticket_category");

                entity.Property(e => e.TicketCategoryId).HasColumnName("ticket_category_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TicketCategories)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_event_id");
            });

            modelBuilder.Entity<TotalNumberOfTicketsPerCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("total_number_of_tickets_per_category");

                entity.Property(e => e.TicketCategoryId).HasColumnName("ticket_category_id");

                entity.Property(e => e.TotalPriceForTickets)
                    .HasColumnType("numeric(38, 2)")
                    .HasColumnName("total_price_for_tickets");

                entity.Property(e => e.TotalTicketsSold).HasColumnName("total_tickets_sold");
            });

            modelBuilder.Entity<Userr>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__userr__B9BE370FB4DC57AF");

                entity.ToTable("userr");

                entity.HasIndex(e => e.Email, "UQ__userr__AB6E61646122BC33")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.ToTable("venue");

                entity.Property(e => e.VenueId).HasColumnName("venue_id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
