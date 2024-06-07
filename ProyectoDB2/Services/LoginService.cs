namespace ProyectoDB2.Services
{
    public class LoginService
    {
        private readonly ApplicationDbContext _context;

        public LoginService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void RegisterUser(string userName, string password)
        {
            _context.RegisterUser(userName, password);
        }

        public (bool success, int? roleId) LoginUser(string userName, string password)
        {
            return _context.LoginUser(userName, password);
        }

    }
}
