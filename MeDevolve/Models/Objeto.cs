using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeDevolve.Models
{
    public class Objeto
    {
        [Key]
        public int IDOBJETO { get; set; }
        public String NOME { get; set; }
    }
}