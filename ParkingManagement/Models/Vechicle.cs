using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ParkingManagement.Models
{
    public class Vechicle
    {
        public int VechicleId { get; set; }
        public int VAvailableCount { get; set; }
        public int VOccupiedCount { get; set; }
        public string VechicleType { get; set; }
        public string VechicleName { get; set; }

        public DataView lstVechicleType { get; set; }
        public DataView lstVechicleName { get; set; }
    }
}