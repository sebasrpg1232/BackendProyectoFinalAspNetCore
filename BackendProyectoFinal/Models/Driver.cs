using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace BackendProyectoFinal.Domain

{
    public class Driver
    {
        public Int64 driverId { get; set; }
        public string driverName { get; set; }
        public string driverDirection { get; set; }
        public string driverEmail { get; set; }
        public Int64 driverNumber { get; set; }
        public string driverPassword { get; set; }

    }
}
