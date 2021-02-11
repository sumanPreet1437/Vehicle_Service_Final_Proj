using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehicle_Service_Final_Proj.Models;

namespace Vehicle_Service_Final_Proj.Models
{
    public class Vehicle_Service_DataContext : DbContext
    {
        public Vehicle_Service_DataContext (DbContextOptions<Vehicle_Service_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle_Service_Final_Proj.Models.Service> Service { get; set; }

        public DbSet<Vehicle_Service_Final_Proj.Models.ServiceBookingRecord> ServiceBookingRecord { get; set; }

        public DbSet<Vehicle_Service_Final_Proj.Models.VehicleOwner> VehicleOwner { get; set; }
    }
}
