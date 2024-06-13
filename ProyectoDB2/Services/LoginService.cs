namespace ProyectoDB2.Services
{
    public class LoginService
    {
        private readonly ApplicationDbContext _context;

        public LoginService(ApplicationDbContext context)
        {
            _context = context;
        }


        public (bool success, int? roleId) LoginUser(string userName, string password)
        {
            return _context.LoginUser(userName, password);
        }

    }
}
