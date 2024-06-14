using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;
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
            modelBuilder.Entity<TipoProductoDTO>().HasNoKey();
			modelBuilder.Entity<ProductoDTO>().HasNoKey();
            modelBuilder.Entity<ClienteDTO>().HasNoKey();
            modelBuilder.Entity<ProductoDTO>().Property(p => p.Precio)
                .HasColumnType("money");
            modelBuilder.Entity<ProductModelSP>().HasKey(p => p.Referencia); // Configurar Referencia como clave primaria
            modelBuilder.Entity<TipoClienteDTO>().HasNoKey();
			modelBuilder.Entity<AdministradorDTO>().HasNoKey();
			modelBuilder.Entity<UsuarioDTO>().HasNoKey();
			modelBuilder.Entity<ReporteVentaDiariaDTO>().HasNoKey();

		}

		public void RegisterUser(int numeroDocumento, string tipoDocumento, string nombreCompleto, string telefonoResidencia, string telefonoCelular, string direccion, string ciudadResidencia, string departamento,string pais, string profesion, string email, int idTipoCliente, string userName, string password, int rol)
        {
            var numeroDocumentoParam = new SqlParameter("@NumeroDocumento", numeroDocumento);
            var tipoDocumentoParam = new SqlParameter("@TipoDocumento", tipoDocumento);
            var nombreCompletoParam = new SqlParameter("@NombreCompleto", nombreCompleto);
            var telefonoResidenciaParam = new SqlParameter("@TelefonoResidencia", telefonoResidencia);
            var telefonoCelularParam = new SqlParameter("@TelefonoCelular", telefonoCelular);
            var direccionParam = new SqlParameter("@Direccion", direccion);
            var ciudadResidenciaParam = new SqlParameter("@CiudadResidencia", ciudadResidencia);
            var departamentoParam = new SqlParameter("@Departamento", departamento);
            var paisParam = new SqlParameter("@Pais", pais);
            var profesionParam = new SqlParameter("@Profesion", profesion);
            var emailParam = new SqlParameter("@Email", email);
            var idTipoClienteParam = new SqlParameter("@IdTipoCliente", idTipoCliente);
            var userNameParam = new SqlParameter("@Username", userName);
            var passwordParam = new SqlParameter("@Password", password);
            var rolParam = new SqlParameter("@RoleId", rol);
            //Database.ExecuteSqlRaw("EXEC RegisterUser @Username, @Password, @RoleId", userNameParam, passwordParam, rolParam);
            Database.ExecuteSqlRaw("EXEC RegisterUser @NumeroDocumento, @TipoDocumento, @NombreCompleto, @TelefonoResidencia, @TelefonoCelular, @Direccion, @CiudadResidencia, @Departamento, @Pais, @Profesion, @Email, @IdTipoCliente, @Username, @Password, @RoleId", numeroDocumentoParam, tipoDocumentoParam, nombreCompletoParam, telefonoResidenciaParam, telefonoCelularParam, direccionParam, ciudadResidenciaParam, departamentoParam, paisParam, profesionParam, emailParam, idTipoClienteParam, userNameParam, passwordParam, rolParam);
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
