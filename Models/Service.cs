using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle_Service_Final_Proj.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string ServiceName { get; set; }

        public decimal ServiceCharge { get; set; }

        public string Description { get; set;  }

    }
}
