using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkAr.Models;
using System.ComponentModel.DataAnnotations;

namespace ParkAr.ViewModels
{
    public class ConfirmacionReservaViewModel
    {
        [Display(Name = "Bo N°")]
        public Box Box { get; set; }

        [Display(Name = "Nombre Cliente")]
        public Cliente Cliente { get; set; }

        [Display(Name = "Tipo Vehiculo")]
        public TipoVehiculo TipoVehiculoSeleccionado { get; set; }

        [Display(Name = "Desde")]
        public DateTime Desde { get; set; }

        [Display(Name = "Hasta")]
        public DateTime Hasta { get; set; }

        [Display(Name = "Estacionamiento")]
        public Estacionamiento EstacionamientoSeleccionado { get; set; }

        [Display(Name = "Vehiculo")]
        public Vehiculo Vehiculo { get; set; }
    }
}