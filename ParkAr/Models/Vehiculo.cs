using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAr.Models
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }

        public string Patente { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public TipoVehiculo TipoVehiculo { get; set; }

        public int TipoVehiculoId { get; set; }

        public Cliente cliente { get; set; }


    }
}