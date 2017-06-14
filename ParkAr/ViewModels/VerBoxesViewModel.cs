using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkAr.Models;

namespace ParkAr.ViewModels
{
    public class VerBoxesViewModel
    {
       
       public Dictionary<int, ICollection<Box>> MapaBoxes { get; set; }
       public String NombreEstacionamiento { get; set; }
    }
}