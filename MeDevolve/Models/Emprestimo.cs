using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeDevolve.Models
{
    public class Emprestimo
    {
        [Key]
        public int IDEMPRESTIMO { get; set; }

        public int IDOBJETO { get; set; }
        [ForeignKey("IDOBJETO")]
        public Objeto OBJETO { get; set; }

        public int IDUSUARIO { get; set; }
        [ForeignKey("IDUSUARIO")]
        public Usuario USUARIO { get; set; }

        public DateTime DATAEMP { get; set; }
        public DateTime DATAPREVDEV { get; set; }
        public DateTime DATADEV { get; set; }

        public List<Objeto> OBJETOS { get; set; }
    }
}