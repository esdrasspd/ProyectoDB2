namespace ProyectoDB2.DTOs
{
    public class ReporteCompraPorClienteDTO
    {
        public DateTime FechaCompra { get; set; }
        public decimal SubTotal { get; set; }
        public string Nombre { get; set; }
        public string Cliente { get; set; }  
    }
}
