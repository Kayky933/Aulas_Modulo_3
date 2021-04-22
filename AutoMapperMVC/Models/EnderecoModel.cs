using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperMVC.Models
{
    public class EnderecoModel
    {
        [Key]
        public int Id_Endereco { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }       
    }
}
