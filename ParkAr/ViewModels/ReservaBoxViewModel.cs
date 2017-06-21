using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkAr.Models;
using System.ComponentModel.DataAnnotations;

namespace ParkAr.ViewModels
{
    public class ReservaBoxViewModel
    {
       
        public Box Box { get; set; }


        [Display(Name = "Nombre Cliente")]
        public Cliente Cliente { get; set; }

        [Display(Name = "Numero Box")]
        public Box BoxSeleccionado { get; set; }

        //public string EstacionamientoSeleccionado { get; set; }

        public string Categoria { get; set; }

        //public string Marca { get; set; }

        //public string Modelo { get; set; }

        public IEnumerable<TipoVehiculo> TipoVehiculos { get; set; }

        public int TipoVehiculoId { get; set; }

        public TipoVehiculo TipoVehiculoSeleccionado { get; set; }

        public DateTime Desde { get; set; }

        public DateTime Hasta { get; set; }


        [Display(Name = "Estacionamiento")]
        public Estacionamiento EstacionamientoSeleccionado { get; set; }

        [Display(Name = "Estacionamientos")]
        public IEnumerable<Estacionamiento> Estacionamientos { set; get; }


        public int EstacionamientoId { get; set; }

        public Vehiculo Vehiculo { get; set; }
        /*
        

        

        [Display(Name = "Horas")]
        public List<String> Horas { get; set; }

        public byte CantidadHoras { set; get; }

       

        
             
        
        public IEnumerable<TipoVehiculo> TipoVehiculos { get; set; }

        public int TipoVehiculoId { get; set; }

        public TipoVehiculo TipoVehiculoSeleccionado { get; set; }
        */
    }
}