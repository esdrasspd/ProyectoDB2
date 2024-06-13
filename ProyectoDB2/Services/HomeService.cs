using Microsoft.EntityFrameworkCore;
using ProyectoDB2.Models;

namespace ProyectoDB2.Services
{
    public class HomeService
    {
        private readonly ApplicationDbContext _context;

        public HomeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProductModelSP> GetProducts()
        {
            return _context.Productos.FromSqlRaw("EXEC sp_ConsultarProductos").ToList();
        }

        public string GetImageSrc(byte[] foto)
        {
            if (foto == null || foto.Length == 0)
            {
                return "";
            }
            var base64 = Convert.ToBase64String(foto);
            return $"data:image/jpeg;base64,{base64}";
        }
    }
}
