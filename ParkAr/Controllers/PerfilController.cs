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
    public class PerfilController : Controller
    {
        private ApplicationDbContext _context;

        public PerfilController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Perfil
        public ActionResult Index()
        {
            /** Esto es para simplificar el desarrollo y no tener que estara logeandose a cada rato */
            var user = _context.Cientes.Include(x => x.Vehiculos).SingleOrDefault(p => p.Email == "ferfigueredo@gmail.com");
            Session["user"] = user;
            /* ********************************************************* */

            Cliente cliente = (Cliente)Session["user"];


            PerfilUserViewModel model = new PerfilUserViewModel()
            {
                Cliente = cliente,
                Vehiculos = getVehiculosOrdenados(cliente.VehiculoPrincipalId, cliente.Vehiculos),
                VehiculoSelId = cliente.VehiculoPrincipalId
            };
            return View(model);
        }

        private ICollection<Vehiculo> getVehiculosOrdenados(int VehiculoPrincipalId, ICollection<Vehiculo> vehiculos)
        {
            ICollection<Vehiculo> autos = new List<Vehiculo>();
            foreach (var item in vehiculos)
            {
                if (item.VehiculoId == VehiculoPrincipalId)
                {
                    autos.Add(item);
                }
            }
            foreach (var item in vehiculos)
            {
                if (item.VehiculoId != VehiculoPrincipalId)
                {
                    autos.Add(item);
                }
            }
            return autos;
        }


        public String EliminarVehiculo(string vehiculoId)
        {
            int id = Int32.Parse(vehiculoId);
           
            Cliente cliente = (Cliente)Session["user"];

            foreach (var vehic in cliente.Vehiculos)
            {
                if (vehic.VehiculoId == id)
                {
                    Vehiculo v = _context.Vehiculos.SingleOrDefault(vi => vi.VehiculoId == vehic.VehiculoId);
                    v.cliente = null;

                    _context.Entry(v).State = EntityState.Modified;
                    _context.SaveChanges();

                    /*
                    _context.Vehiculos.Attach(v);
                    _context.Entry(v).State = EntityState.Modified;
                    var entry = _context.Entry(v);
                    if(TryUpdateModel(v, "", new String[] { "cliente" }))
                    {
                        _context.SaveChanges();
                    }
                    //_context.Entry(v).State = System.Data.Entity.EntityState.Modified;
                    */
                    
                    break;
                }
            }

            return "SUCCESS";
        }

        public String SetearVehiculoPrincipal(string vehiculoId)
        {
            int id = Int32.Parse(vehiculoId);
            Cliente cliente = (Cliente)Session["user"];
            cliente = _context.Cientes.SingleOrDefault(c => c.ClienteId == cliente.ClienteId);

            cliente.VehiculoPrincipalId = id;
            _context.SaveChanges();
            return "SUCCESS";
        }
    }
}