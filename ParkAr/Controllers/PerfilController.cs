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


            var model = new PerfilUserViewModel
            {
                Cliente = cliente,
                Vehiculos = cliente.Vehiculos,
                VehiculoSelId = cliente.VehiculoPrincipalId
            };
            return View();
        }
    }
}