using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAr.Models
{
    public class PagoReserva
    {
        public int PagoReservaId { get; set; }

        public int Monto { get; set; }

        public string MedioPago { get; set; }

        public DateTime Fecha { get; set; }

    }
}