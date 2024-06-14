namespace ProyectoDB2.DTOs
{
	public class ReporteVentaDiariaDTO
	{
        public DateTime FechaCompra { get; set; }
        public string TipoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Ciudad { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaGeneracion { get; set; }
    }
}
