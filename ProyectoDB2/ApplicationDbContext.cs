using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.Entityes;
using ProyectoDB2.Models;
using System.Data;

namespace ProyectoDB2
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProductModelSP> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModelSP>().HasKey(p => p.Referencia); // Configurar Referencia como clave primaria
        }

        public void RegisterUser(string userName, string password, int rol)
        {
            var userNameParam = new SqlParameter("@Username", userName);
            var passwordParam = new SqlParameter("@Password", password);
            var rolParam = new SqlParameter("@RoleId", rol);
            Database.ExecuteSqlRaw("EXEC RegisterUser @Username, @Password, @RoleId", userNameParam, passwordParam, rolParam);
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
        public void BuyProcess(int numeroDocumentoCliente, string referenciaProducto, decimal precio, int cantidad )
        {
            var numeroDocumentoClienteParam = new SqlParameter("@NumeroDocumentoCliente", numeroDocumentoCliente);
            var referenciaProductoParam = new SqlParameter("@ReferenciaProducto", referenciaProducto);
            var precioParam = new SqlParameter("@Precio", precio);
            var cantidadParam = new SqlParameter("@Cantidad", cantidad);
            Database.ExecuteSqlRaw("EXEC sp_ProcesarCompra @NumeroDocumentoCliente, @ReferenciaProducto, @Precio, @Cantidad", numeroDocumentoClienteParam, referenciaProductoParam, precioParam, cantidadParam );
        }
    }

}
