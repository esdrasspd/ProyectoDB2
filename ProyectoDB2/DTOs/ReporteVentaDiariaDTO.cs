namespace ProyectoDB2.DTOs
{
	public class ReporteVentaDiariaDTO
	{
        public DateTime FechaCompra { get; set; }
        public string TipoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Ciudad { get; set; }
        public int Cantidad { get; set; }

        public double CostoUnitario { get;}
        public double SubTotal { get; set; }
    }
}
