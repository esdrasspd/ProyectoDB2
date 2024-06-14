namespace ProyectoDB2.DTOs
{
	public class ProductoDTO
	{
		public string Referencia { get; set; } = "";
		public string Nombre { get; set; } = "";
		public string Descripcion { get; set; } = "";
		public string TipoProducto { get; set; } = "";
		public string Material { get; set; } = "";
		public decimal Alto { get; set; }
		public decimal Ancho { get; set; }
		public decimal Profundidad { get; set; }
		public string Color { get; set; } = "";
		public int Peso { get; set; }
		public int Stock { get; set; }
		public decimal Precio { get; set; }
		public string? Foto { get; set; }
		public int IdTipoProducto { get; set; }
	}
}
