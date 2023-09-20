using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace mvcprojectfinal.Models
{
    public class Context : IdentityDbContext<AppliacationUser>
    {
        public Context() { }
        public Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-C91LV05\SQL19;Initial Catalog=RoyalHotelDB;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<FeedBack> feedBacks { get; set; }
        public DbSet<Fun> funs { get; set; }
        public DbSet<Hotels> hotels { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Booking> booking { get; set; }
        public DbSet<AppliacationUser> appliacationUsers { get; set; }
        public DbSet<RoomVisits> roomVisits { get; set; }
        public DbSet<Images> images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 1,
                Name = "dahab",
                Image = "dahab.jpg"

            });
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 2,
                Name = "Alex",
                Image = "alex.jpg"

            });
            modelBuilder.Entity<Fun>().HasData(new Fun
            {
                Id = 1,
                IsContainsAquaBark = true,
                IsContainsBeach = false,
                IsContainsDesco = true,
                IsContaintsSwimmingPool = true,
                IsHavingElevator = false,
                IsHavingKidsArea = true,
                IsHavingParking = true,
                IsOpenBuffit = false,
                Stars = 4


            });
            modelBuilder.Entity<Fun>().HasData(new Fun
            {
                Id = 2,
                IsContainsAquaBark = true,
                IsContainsBeach = true,
                IsContainsDesco = false,
                IsContaintsSwimmingPool = true,
                IsHavingElevator = true,
                IsHavingKidsArea = false,
                IsHavingParking = true,
                IsOpenBuffit = false,
                Stars = 5


            });
            //modelBuilder.Entity<Hotels>().HasData(new Hotels
            //{
            //    id = 1,
            //    CityID = 1,
            //    FunID = 1,
            //    name = "Four Season",
            //    Description = "Beautiful",
            //    Location="Dahab",
                


            //});
            //modelBuilder.Entity<Hotels>().HasData(new Hotels
            //{
            //    id = 2,
            //    CityID = 2,
            //    FunID = 2,
            //    name = "CeloPetra",
            //    Description = "Beautiful",
            //    Location = "Alex",



            //});
            //modelBuilder.Entity<Images>().HasData(new Images
            //{
            //    id = 1,
            //   source = "dahab.jpg",
            //   HotelsId = 1



            //});
            //modelBuilder.Entity<Images>().HasData(new Images
            //{
            //    id = 2,
            //    source = "ein.jpg",
            //    HotelsId = 1



            //});
            //modelBuilder.Entity<Images>().HasData(new Images
            //{
            //    id = 3,
            //    source = "fayoum.jpg",
            //    HotelsId = 1



            //});
            //modelBuilder.Entity<Images>().HasData(new Images
            //{
            //    id = 4,
            //    source = "Giza.png",
            //    HotelsId = 2



            //});
            //modelBuilder.Entity<Images>().HasData(new Images
            //{
            //    id = 5,
            //    source = "luxor.jpg",
            //    HotelsId = 2



            //});
            //modelBuilder.Entity<Room>().HasData(new Room
            //{
            //    ID = 1,
            //    HotelId = 1,
            //    Type = "single",
            //    IsHavingAirconditioning = true,
            //    IsHavingTv = true,
            //    IsReserved = false,
            //    price = 1000,
            //    View = "onBeach"



            //});
            //modelBuilder.Entity<Room>().HasData(new Room
            //{
            //    ID = 2,
            //    HotelId = 1,
            //    Type = "double",
            //    IsHavingAirconditioning = false,
            //    IsHavingTv = true,
            //    IsReserved = false,
            //    price = 500,
            //    View = "onSwimmingBool"



            //});
            //modelBuilder.Entity<Room>().HasData(new Room
            //{
            //    ID = 3,
            //    HotelId = 2,
            //    Type = "triple",
            //    IsHavingAirconditioning = true,
            //    IsHavingTv = true,
            //    IsReserved = false,
            //    price = 1200,
            //    View = "onBeach"



            //});



        }
    }
}