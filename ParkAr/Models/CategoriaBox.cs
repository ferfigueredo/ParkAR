using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkAr.Models
{
    public class CategoriaBox
    {

        public int CategoriaBoxId { get; set; }


        [Display(Name = "Categoria Box")]
        public string Descripcion { get; set; }
       

    }
}