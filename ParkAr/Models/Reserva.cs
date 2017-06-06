using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAr.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }

        public Vehiculo Vehiculo { get; set; }

        public Box Box { get; set; }

        public int BoxId { get; set; }

        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public EstadoReserva  EstadoReserva{ get; set; }

    }
}