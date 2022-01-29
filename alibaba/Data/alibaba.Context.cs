using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

namespace Data
{
    public partial class alibabaEntities : DbContext
    {
        public static IConfiguration _config { get; }
        public static string connectionString = _config["ConnectionStrings:Default"];

        public alibabaEntities() : base(GetOptions(connectionString)) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new Exception();
        }

        public virtual DbSet<Bus> Bus { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Foreign> Foreign { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelOrder> HotelOrder { get; set; }
        public virtual DbSet<Internal> Internal { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<TripTicket> TripTicket { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UsersWithNonZeroBalance> UsersWithNonZeroBalance { get; set; }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

    }
}
