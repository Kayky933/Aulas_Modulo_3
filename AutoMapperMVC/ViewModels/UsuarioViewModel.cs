using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperMVC.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id_Usuario { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Street { get; set; }
        public string Number { get; set; }
    }
}
