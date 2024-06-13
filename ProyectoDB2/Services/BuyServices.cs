namespace ProyectoDB2.Services
{
    public class BuyServices
    {
        private readonly ApplicationDbContext _context;

        public BuyServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void BuyProcess(int numeroDocumentoCliente, string referenciaProducto, decimal precio, int cantidad)
        {
            _context.BuyProcess(numeroDocumentoCliente, referenciaProducto, precio, cantidad);
        }
    }
}
