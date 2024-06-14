using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;
using ProyectoDB2.Models;

namespace ProyectoDB2
{
	public class ReportsDbContext : DbContext
	{
		public ReportsDbContext(DbContextOptions<ReportsDbContext> options) : base(options)
		{
		}

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
			modelBuilder.Entity<ReporteProductoMasVendidoDTO>().HasNoKey();
            modelBuilder.Entity<ReporteCierreCajaDTO>().HasNoKey();
            modelBuilder.Entity<ReporteCompraPorClienteDTO>().HasNoKey();
        }
	}
}
