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
            var estacionamientos = _context.Estacionamientos.Include(e => e.Boxes).ToList();
            var model = new ReservaBoxViewModel
            {
                Cliente = new Cliente(),
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

           // cliente = _context.Cientes.Include(x => x.Vehiculos).SingleOrDefault(x => x.ClienteId == cliente.ClienteId);


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
                Desde = new DateTime(),
                Hasta = new DateTime()

            };
           
            return View("ReservaBox", model);

        }

        [HttpPost]
        public ActionResult GenerarReserva(String boxID, String estacionamientoID, String desde, String hasta, String marca, 
            String patente, String modelo, String usuario)
        {
            // traigo las reservas que tengo de la base de Datos para luego comparar
            //var reservasDb = _context.Reservas.Include(x => x.Box).ToList();

            var tempReserva = new Reserva();

            EstadoBox estadoBoxReservado = _context.EstadosBox.SingleOrDefault(y => y.EstadoBoxId == 3);
         

            int boxIdInt = Int32.Parse(boxID);
             Box boxSeleccionado = _context.Boxes.Include(x => x.CategoriaBox).Include(x => x.EstadoBox).SingleOrDefault(x => x.BoxId == boxIdInt);
             boxSeleccionado.EstadoBox = estadoBoxReservado;
             //_context.Boxes.Add(boxSeleccionado);

            
            DateTime dtDesde = Convert.ToDateTime(desde);
            DateTime dtHasta = Convert.ToDateTime(hasta);
            
           
            Cliente cliente = (Cliente)Session["user"];           

            cliente = _context.Cientes.Include(x => x.Vehiculos).SingleOrDefault(p => p.ClienteId == cliente.ClienteId);

            Vehiculo vehiculo = cliente.getVehiculoPrincipal();
            //tempReserva.BoxId = reservaModel.Box.BoxId;
            var estadoReserva = _context.EstadoReservas.SingleOrDefault(x => x.EstadoReservaId == 1);

            

            tempReserva.FechaDesde = dtDesde;
            tempReserva.FechaHasta = dtHasta;
            tempReserva.Vehiculo = vehiculo;
            tempReserva.Box = boxSeleccionado;
            tempReserva.EstadoReserva = estadoReserva;
            tempReserva.BoxId = boxSeleccionado.BoxId;

             _context.Reservas.Add(tempReserva);

             _context.SaveChanges();
             
            return View();
        }
   


      

        public PartialViewResult GetEstacionamiento(int id /* drop down value */)
        {
            var model = _context.Estacionamientos.Find(id); // This is for example put your code to fetch record. 
            
            return PartialView("_Details", model);
        }
    }

   

}