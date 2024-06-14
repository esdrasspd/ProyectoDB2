using System.ComponentModel.DataAnnotations;

namespace ProyectoDB2.Models
{
    public class RegisterModel
    {
        
        public int NumeroDocumento { get; set; }

        public string TipoDocumento { get; set; }

        public string NombreCompleto { get; set; }

        public string TelefonoResidencia { get; set; }

        public string TelefonoCelular { get; set; }

        public string Direccion { get; set; }

        public string CiudadResidencia { get; set; }
        public string Departamento { get; set; }

        public string Pais { get; set; }
        public string Profesion { get; set; }
        public string Email { get; set; }
        public int IdTipoCliente { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
