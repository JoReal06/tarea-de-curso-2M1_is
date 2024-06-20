using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class LoginUsuarioDto
    {
        [Required]
        public string nombreDeUsuario { get; set; }
        [Required]
        public string contraseña { get; set; }
    }
}
