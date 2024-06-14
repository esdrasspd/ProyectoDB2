namespace ProyectoDB2.DTOs
{
	public class ClienteDTO
	{
		public string TipoDocumento { get; set; } = string.Empty;
		public int NumeroDocumento { get; set; }
		public string NombreCompleto { get; set; } = string.Empty;
		public string TelefonoResidencia { get; set; } = string.Empty;
		public string TelefonoCelular { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
		public string CiudadResidencia { get; set; } = string.Empty;
		public string Departamento { get; set; } = string.Empty;
		public string Pais { get; set; } = string.Empty;
		public string Profesion { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public int IdTipoCliente { get; set; }
		public int IdUsuario { get; set; }
		public string Nit { get; set; } = string.Empty;
		public string NombreTipoCliente { get; set; } = string.Empty;
		public string Username { get; set; } = string.Empty;
	}
}
