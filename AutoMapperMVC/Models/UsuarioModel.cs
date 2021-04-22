using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperMVC.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        public int Id_Usuario { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }

        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}
