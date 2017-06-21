using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkAr.Models;

namespace ParkAr.ViewModels
{
    public class VerBoxesViewModel
    {
        private Random RND;

        public VerBoxesViewModel()
        {
            RND = new Random();
        }
        public int GetRandom()
        {
            return RND.Next(2, 3);
        }
        public Dictionary<int, ICollection<Box>> MapaBoxes { get; set; }
       public String NombreEstacionamiento { get; set; }
    }
}