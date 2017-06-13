using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAr.Models
{
    public class Estacionamiento
    {
        
        public int EstacionamientoId { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public ICollection<Box> Boxes { get; set; }



        public Estacionamiento()
        {
            this.Boxes = new List<Box>();
        }
    }
}