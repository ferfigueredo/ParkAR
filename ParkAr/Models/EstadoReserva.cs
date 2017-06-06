using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAr.Models
{
    public class EstadoReserva
    {
        public EstadoReserva(int id)
        {
            EstadoReservaId = id;
        }

        public EstadoReserva()
        {

        }


        public int EstadoReservaId { get; set; }

        public string Descripcion { get; set; } 

    }
}