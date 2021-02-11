using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle_Service_Final_Proj.Models
{
    public class ServiceBookingRecord
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public int VehicleOwnerId { get; set; }

        public Service Service { get; set; }

        public VehicleOwner VehicleOwner  {get; set; }
    }
}
