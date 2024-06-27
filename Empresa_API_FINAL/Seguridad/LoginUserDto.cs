using System.ComponentModel.DataAnnotations;

namespace Empresa_API_FINAL.Seguridad
{
    public class LoginUserDto
    {
        [Required]
        public string nombreUsurio { get; set; }
        [Required]
        public string Contraseña { get; set; }
    }
}
