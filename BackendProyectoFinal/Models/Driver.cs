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
        public Int32 driverId { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        
        public string correo { get; set; }
        public Int32 numero{ get; set; }

    }
}
