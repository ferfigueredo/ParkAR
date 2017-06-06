using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParkAr.Models
{
        public class Box
        {
           [Key]
            public int BoxId { get; set; }

            public int Piso { get; set; }

            public int Numero { get; set; }


            public int EstacionamientoId { get; set; }
            public virtual Estacionamiento Estacionamiento { get; set; }

            public EstadoBox EstadoBox { get; set; }
        
            public int EstadoBoxId { get; set; }

        
            public CategoriaBox CategoriaBox { get; set; }

            public int CategoriaBoxId { get; set; }
         }
}