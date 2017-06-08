using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkAr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Somos un grupo de jovenes emprendedores que creemos que estamos en la faz de la tierra para hacer grandes cosas. Estamos constantemente centrados en la innovación. Creemos en lo simple no en lo complejo. Creemos que necesitamos poseer y controlar las tecnologías primarias detrás de los servicios que hacemos, y participar solamente en los mercados donde podemos hacer una contribución significativa. Creemos en decir no a miles de proyectos, para que realmente podamos concentrarnos en los pocos que son verdaderamente importantes y significativos para nosotros. Creemos en la profunda colaboración y polinización cruzada de nuestros grupos, que nos permiten innovar de una manera que otros no pueden. Y francamente, no nos conformamos con nada menos que la excelencia en cada area de la empresa, y tenemos la honestidad de sí mismo para admitir que estamos equivocados y el coraje para cambiar. Y creo que independientemente de quién está haciendo que parte del trabajo los valores están tan incrustados en esta empresa que estamos convencidos de que nos ira muy bien.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nuestros medios de contacto";
            ViewBag.Title = "Contacto";

            return View();
        }
    }
}