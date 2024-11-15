using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace RZA_AR.Models;

public partial class TlS2302631RzaZooContext : DbContext
{
    public TlS2302631RzaZooContext()
    {
    }

    public TlS2302631RzaZooContext(DbContextOptions<TlS2302631RzaZooContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roombooking> Roombookings { get; set; }

    public virtual DbSet<Zoobooking> Zoobookings { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseMySql("name=MySqlConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.Loyaltypoints).HasColumnName("loyaltypoints");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("phonenumber");
            entity.Property(e => e.Postcode)
                .HasMaxLength(8)
                .HasColumnName("postcode");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Roomnumber).HasName("PRIMARY");

            entity.ToTable("rooms");

            entity.Property(e => e.Roomnumber)
                .ValueGeneratedNever()
                .HasColumnName("roomnumber");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.RoomType)
                .HasMaxLength(20)
                .HasColumnName("roomType");
        });

        modelBuilder.Entity<Roombooking>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.RoomNumber, e.CheckinDate })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("roombookings");

            entity.HasIndex(e => e.RoomNumber, "roomNumber");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");
            entity.Property(e => e.CheckinDate).HasColumnName("checkinDate");
            entity.Property(e => e.CheckoutDate).HasColumnName("checkoutDate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Roombookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cid");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.Roombookings)
                .HasForeignKey(d => d.RoomNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roombookings_ibfk_2");
        });

        modelBuilder.Entity<Zoobooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PRIMARY");

            entity.ToTable("zoobookings");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("bookingID");
            entity.Property(e => e.NumberofGuests).HasColumnName("numberofGuests");
            entity.Property(e => e.TicketType)
                .HasMaxLength(20)
                .HasColumnName("ticketType");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
            entity.Property(e => e.VisitDate).HasColumnName("visitDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
