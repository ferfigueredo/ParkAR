using ParkAr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParkAr.ViewModels
{
    public class PerfilUserViewModel
    {
        [Display(Name = "Nombre Cliente")]
        public Cliente Cliente { get; set; }

        public Vehiculo NuevoVehiculo { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }

        public int VehiculoSelId { get; set; }


    }
}