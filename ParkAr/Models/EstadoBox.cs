﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParkAr.Models
{
    public class EstadoBox
    {

        public EstadoBox(int id)
        {
            EstadoBoxId = id;
        }

        public EstadoBox()
        {

        }
        public int EstadoBoxId { get; set; }


        public string Descripcion { get; set; }

        

        
    }
}