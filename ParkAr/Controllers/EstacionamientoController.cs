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

        // Prueba de pasar parámetro por URL o embebido en la la URL
        // En este caso va a tirar error porque el RouterConfig.cs tiene como default {id} y yo tengo definido pruebaId
        //http://localhost:49557/Estacionamiento/Prueba/232


        // Prueba de pasar parámetro en el query string
        //http://localhost:49557/Estacionamiento/Prueba?id=1
        // Va a tira
        public ActionResult Prueba (int? pruebaId)
        {
            if (!pruebaId.HasValue)
            {
                pruebaId = 18;
            }
            

            return Content(String.Format("ID={0}", pruebaId));
            
        }

        public ActionResult Prueba2(int? prueba2Id, string parametro)
        {
            if (!prueba2Id.HasValue)
            {
                prueba2Id = 1;
            }

            if (String.IsNullOrWhiteSpace(parametro))
            {
                parametro = "Octavio";
            }

            return Content(String.Format("Parametro={1},Valor={0}", parametro, prueba2Id));
        }

        // GET: Estacionamiento
        /*public ActionResult Index2()
        {
            List<EstadoBox> estadosBox = new List<EstadoBox>
            {
                new EstadoBox {EstadoBoxId = 1, Descripcion="Libre"},
                new EstadoBox {EstadoBoxId = 2, Descripcion="Ocupado"},
                new EstadoBox {EstadoBoxId = 3, Descripcion="Reservado"}
            };

            List<Box> boxes = new List<Box>
            {
                new Box {BoxId = 1, Piso =1, Numero=10, CategoriaBoxId=1},
                new Box {BoxId = 2, Piso =1, Numero=11, CategoriaBoxId=1},
                new Box {BoxId = 3, Piso =2, Numero=20, CategoriaBoxId=2},
                new Box {BoxId = 4, Piso =3, Numero=33, CategoriaBoxId=3},
                new Box {BoxId = 5, Piso =4, Numero=44, CategoriaBoxId=3}
            };

            var estacionamiento = new Estacionamiento()
            {
                EstacionamientoId = 1,
                Direccion="Palermo",
                Boxes = boxes
            };
            return View(estacionamiento);
        }
        */
        public ActionResult Index()
        {
            //var estacionamientos = _context.Estacionamientos.Include("Boxes").ToList();
            var estacionamientos = _context.Estacionamientos.Include(e => e.Boxes).ToList();

            var s = Session;

            //var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            // Aca entity framework no hace un query a la base. Es lo que se llama un defered execution
            // El query consultará en la base, cuando en el avisa recorra con el foreach
            // con el ToList() inmediatamente hago el query en la base
            // Include(c => c.MemberShipType) es la relación que hace para unir la tabla Customer -> Membershiptype
            // Se hace un Eager Loading
            // Por default, entity framework no crea las relaciones

            var model = new ReservaBoxViewModel
            {
                Cliente = new Cliente(),
                Estacionamientos = estacionamientos

            };
            return View(model);
        }

        public ActionResult Index3(string estacionamientoID)
        {
            //var estacionamientos = _context.Estacionamientos.Include("Boxes").ToList();
            int id = Int32.Parse(estacionamientoID);
            var estacionamiento = _context.Estacionamientos
                                    .Include(x => x.Boxes.Select(y => y.EstadoBox)).SingleOrDefault(x => x.EstacionamientoId == id);
            //var estacionamiento2 = _context.Estacionamientos.Include(e => e.Boxes).SingleOrDefault(e => e.EstacionamientoId == 1);



            //var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            // Aca entity framework no hace un query a la base. Es lo que se llama un defered execution
            // El query consultará en la base, cuando en el avisa recorra con el foreach
            // con el ToList() inmediatamente hago el query en la base
            // Include(c => c.MemberShipType) es la relación que hace para unir la tabla Customer -> Membershiptype
            // Se hace un Eager Loading
            // Por default, entity framework no crea las relaciones

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

            cliente = _context.Cientes.Include(x => x.Vehiculos).SingleOrDefault(x => x.ClienteId == cliente.ClienteId);


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
            /*var model = new ReservaBoxViewModel()
            {
                EstacionamientoSeleccionado = estacionamientoSeleccionado,
                Estacionamientos = estacionamientos,
                Cliente = cliente,
                BoxSeleccionado = boxSeleccionado,
                TipoVehiculos = tipoVehiculos
            };
            */
            return View("ReservarBox", model);

        }

        [HttpPost]
        public ActionResult GenerarReserva(String boxID, String estacionamientoID, String desde, String hasta, String marca, 
            String patente, String modelo, String usuario)
        {
            // traigo las reservas que tengo de la base de Datos para luego comparar
            //var reservasDb = _context.Reservas.Include(x => x.Box).ToList();

            var tempReserva = new Reserva();


            int boxIdInt = Int32.Parse(boxID);
             Box boxSeleccionado = _context.Boxes.Include(x => x.CategoriaBox).Include(x => x.EstadoBox).SingleOrDefault(x => x.BoxId == boxIdInt);
             boxSeleccionado.EstadoBox = new EstadoBox(3);
             _context.Boxes.Add(boxSeleccionado);

            
            DateTime dtDesde = Convert.ToDateTime(desde);
            DateTime dtHasta = Convert.ToDateTime(hasta);
            
            IFormatProvider culture = new System.Globalization.CultureInfo("es-ES", true);

           
            DateTime dt1 = DateTime.Parse(desde, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            DateTime dt2 = DateTime.Parse(hasta, culture, System.Globalization.DateTimeStyles.AssumeLocal);

            Cliente cliente = (Cliente)Session["user"];

            cliente = _context.Cientes.Include(x => x.Vehiculos).SingleOrDefault(x => x.ClienteId == cliente.ClienteId);


            Vehiculo vehiculo = cliente.getVehiculoPrincipal();

            //tempReserva.BoxId = reservaModel.Box.BoxId;
            tempReserva.FechaDesde = dtDesde;
            tempReserva.FechaHasta = dtHasta;
            tempReserva.Vehiculo = vehiculo;
            tempReserva.Box = boxSeleccionado;
            tempReserva.EstadoReserva = new EstadoReserva(1);
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