using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.Entityes;
using System.Data;

namespace ProyectoDB2
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public void RegisterUser(string userName, string password)
        {
            var userNameParam = new SqlParameter("@Username", userName);
            var passwordParam = new SqlParameter("@Password", password);
            Database.ExecuteSqlRaw("EXEC RegisterUser @Username, @Password", userNameParam, passwordParam);
        }

        public (bool success, int? roleId) LoginUser(string username, string password)
        {
            var usernameParam = new SqlParameter("@Username", username);
            var passwordParam = new SqlParameter("@Password", password);
            var userFoundParam = new SqlParameter("@UserFound", SqlDbType.Bit) { Direction = ParameterDirection.Output };
            var roleIdParam = new SqlParameter("@RoleId", SqlDbType.Int) { Direction = ParameterDirection.Output };

            Database.ExecuteSqlRaw("EXEC LoginUser @Username, @Password, @UserFound OUTPUT, @RoleId OUTPUT", usernameParam, passwordParam, userFoundParam, roleIdParam);

            // Leer el valor de retorno del procedimiento almacenado
            bool userFound = (bool)userFoundParam.Value;
            int? roleId = null;
            if (roleIdParam.Value != DBNull.Value)
            {
                roleId = (int)roleIdParam.Value;
            }

            return (userFound, roleId);
        }
    }

}
