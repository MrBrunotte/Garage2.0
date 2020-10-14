using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Models;

namespace Garage2._0.Data
{
    public class Garage2_0Context : DbContext
    {
        public Garage2_0Context (DbContextOptions<Garage2_0Context> options)
            : base(options)
        {
        }

        public DbSet<Garage2._0.Models.ParkedVehicle> ParkedVehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            modelbuilder.Entity<ParkedVehicle>()
                .HasData(

                new ParkedVehicle
                {
                    ID = 1,
                    VehicleType = VehicleType.SportsCar,
                    RegNum = "FZK678",
                    Color = "Black",
                    Make = "Dodge",
                    Model = "Nitro TR 4/4",
                    NumOfWheels = 4,
                    ArrivalTime = DateTime.Parse("2020-10-14"),
                },
                new ParkedVehicle
                {
                    ID = 2,
                    VehicleType = VehicleType.SportsCar,
                    RegNum = "FZK677",
                    Color = "Black",
                    Make = "Camaro",
                    Model = "SS",
                    NumOfWheels = 4,
                    ArrivalTime = DateTime.Parse("2020-10-14"),

                },
                new ParkedVehicle
                {
                    ID = 3,
                    VehicleType = VehicleType.Motorcycle,
                    RegNum = "MKT677",
                    Color = "Orange",
                    Make = "Harley Davidson",
                    Model = "NightRod",
                    NumOfWheels = 2,
                    ArrivalTime = DateTime.Parse("2020-10-14"),
                }

                );
        }


    }
}
