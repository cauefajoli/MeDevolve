using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeDevolve.Models
{
    public class Usuario
    {
        [Key]
        public int IDUSUARIO { get; set; }
        public String NOME { get; set; }
        public String EMAIL { get; set; }
        public String SENHA { get; set; }
    }
}