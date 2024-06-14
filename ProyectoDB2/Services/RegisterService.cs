using Microsoft.EntityFrameworkCore;

namespace ProyectoDB2.Services
{
    public class RegisterService
    {
        private readonly ApplicationDbContext _context;

        public RegisterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void RegisterUser(int numeroDocumento, string tipoDocumento, string nombreCompleto, string telefonoResidencia, string telefonoCelular, string direccion, string ciudadResidencia, string departamento, string pais, string profesion, string email, int idTipoCliente, string userName, string password, int rol)
        {
            _context.RegisterUser(numeroDocumento, tipoDocumento, nombreCompleto, telefonoResidencia, telefonoCelular, direccion, ciudadResidencia, departamento, pais, profesion, email, idTipoCliente, userName, password, rol);
        }
    }
}
