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
        public void RegisterUser(string userName, string password, int rol)
        {
            _context.RegisterUser(userName, password, rol);
        }
    }
}
