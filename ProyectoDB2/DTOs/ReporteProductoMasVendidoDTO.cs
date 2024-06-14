namespace ProyectoDB2.DTOs
{
    public class ReporteProductoMasVendidoDTO
    {
        public string Producto { get; set; }
        public int Cantidades { get; set; }
        public string Ciudad { get; set; }
        public string TipoProducto { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinn { get; set; }
    }
}
