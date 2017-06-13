using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkAr.Models;
using System.Data.Entity;
using ParkAr.ViewModels;

namespace ParkAr.Controllers
{
    public class EstacionamientoController : Controller
    {

        private ApplicationDbContext _context;

        public EstacionamientoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
        public ActionResult Index()
        {
            /** Esto es para simplificar el desarrollo y no tener que estara logeandose a cada rato */
            var user = _context.Cientes.Include(x => x.Vehiculos).SingleOrDefault(p => p.Email == "ferfigueredo@gmail.com");
            Cliente cliente = (Cliente)user;
            Session["user"] = cliente;

            var estacionamientos = _context.Estacionamientos.Include(e => e.Boxes).ToList();
            var model = new ReservaBoxViewModel
            {
                Cliente = (Cliente)Session["user"],
                Estacionamientos = estacionamientos

            };          


            return View(model);
        }

        public ActionResult VerBoxes(string estacionamientoID)
        {
            //var estacionamientos = _context.Estacionamientos.Include("Boxes").ToList();
            int id = Int32.Parse(estacionamientoID);
            var estacionamiento = _context.Estacionamientos
                                    .Include(x => x.Boxes.Select(y => y.EstadoBox)).SingleOrDefault(x => x.EstacionamientoId == id);

            /* **** Para agregar Boxes a un estacionamiento ***** */

           /* EstadoBox estadoBoxLibre = _context.EstadosBox.SingleOrDefault(y => y.EstadoBoxId == 1);
            CategoriaBox categoria = _context.CategoriasBox.SingleOrDefault(y => y.CategoriaBoxId == 1);
            int i = 41;
            while (i < 81) {
                Box box = new Box()
                {
                    Piso = 2,
                    Numero = i,
                    EstacionamientoId = estacionamiento.EstacionamientoId,
                    Estacionamiento = estacionamiento,
                    EstadoBox = estadoBoxLibre,
                    EstadoBoxId = estadoBoxLibre.EstadoBoxId,
                    CategoriaBox = categoria,
                    CategoriaBoxId = categoria.CategoriaBoxId
                    
                };
                i++;
                _context.Boxes.Add(box);
            }
            _context.SaveChanges();*/


            return View(estacionamiento);
        }

        public ActionResult ReservarBox(string boxId, string estacionamientoId)
        {
            int id = Int32.Parse(boxId);
            int estacionamientoIdSeleccionado = Int32.Parse(estacionamientoId);
            var box = _context.Boxes.SingleOrDefault(x => x.BoxId == id);
            List < string > horas = new List<string>(new string[] { "1", "2", "3" });

            var estacionamientoSeleccionado = _context.Estacionamientos.
                                Include(x => x.Boxes.Select(y => y.EstadoBox)).Include(x => x.Boxes.Select(y => y.CategoriaBox)).SingleOrDefault(x => x.EstacionamientoId == estacionamientoIdSeleccionado);

            var boxSeleccionado = _context.Boxes.Include(x => x.CategoriaBox).Include(x => x.EstadoBox).SingleOrDefault(x => x.BoxId == id);

            Cliente cliente = (Cliente)Session["user"];

            Vehiculo vehiculo = cliente.getVehiculoPrincipal();

            var estacionamientos = _context.Estacionamientos.ToList();
            var tipoVehiculos = _context.TipoVehiculos.ToList();

            var model = new ReservaBoxViewModel()
            {
                BoxSeleccionado = boxSeleccionado,
                Cliente = cliente,
                TipoVehiculos = tipoVehiculos,
                EstacionamientoSeleccionado = estacionamientoSeleccionado,
                Vehiculo = vehiculo ,
                Desde = DateTime.Now,
                Hasta = DateTime.Now

            };
           
            return View("ReservaBox", model);

        }

        [HttpPost]
        public ActionResult GenerarReserva(String boxID, String estacionamientoID, String desde, String hasta, String vehiculoSel)
        {
            // traigo las reservas que tengo de la base de Datos para luego comparar
            //var reservasDb = _context.Reservas.Include(x => x.Box).ToList();

            var tempReserva = new Reserva();

            EstadoBox estadoBoxReservado = _context.EstadosBox.SingleOrDefault(y => y.EstadoBoxId == 3);
         

            int boxIdInt = Int32.Parse(boxID);
             Box boxSeleccionado = _context.Boxes.Include(x => x.CategoriaBox).Include(x => x.EstadoBox).SingleOrDefault(x => x.BoxId == boxIdInt);
             boxSeleccionado.EstadoBox = estadoBoxReservado;
            
            DateTime dtDesde = Convert.ToDateTime(desde);
            DateTime dtHasta = Convert.ToDateTime(hasta);
            
           
            Cliente cliente = (Cliente)Session["user"];           

            cliente = _context.Cientes.Include(x => x.Vehiculos).SingleOrDefault(p => p.ClienteId == cliente.ClienteId);

            
            int vehiculoSelId = Int32.Parse(vehiculoSel);
            Vehiculo vehiculoSeleccionado = _context.Vehiculos.SingleOrDefault(x => x.VehiculoId == vehiculoSelId);

            
            //tempReserva.BoxId = reservaModel.Box.BoxId;
            var estadoReserva = _context.EstadoReservas.SingleOrDefault(x => x.EstadoReservaId == 1);            

            tempReserva.FechaDesde = dtDesde;
            tempReserva.FechaHasta = dtHasta;
            tempReserva.Vehiculo = vehiculoSeleccionado;
            tempReserva.Box = boxSeleccionado;
            tempReserva.EstadoReserva = estadoReserva;
            tempReserva.BoxId = boxSeleccionado.BoxId;

             _context.Reservas.Add(tempReserva);

             _context.SaveChanges();

            int estacionamientoIdInt = Int32.Parse(estacionamientoID);
            var estacionamiento = _context.Estacionamientos.SingleOrDefault(x => x.EstacionamientoId == estacionamientoIdInt);


            var model = new ConfirmacionReservaViewModel()
            {
                Box = boxSeleccionado,
                Cliente = cliente,
                TipoVehiculoSeleccionado = vehiculoSeleccionado.TipoVehiculo,
                EstacionamientoSeleccionado = estacionamiento,
                Vehiculo = vehiculoSeleccionado,
                Desde = dtDesde,
                Hasta = dtHasta

            };

            return View("ConfirmacionReserva", model);
        }
   


      

        public PartialViewResult GetEstacionamiento(int id /* drop down value */)
        {
            var model = _context.Estacionamientos.Find(id); // This is for example put your code to fetch record. 
            
            return PartialView("_Details", model);
        }
    }

   

}