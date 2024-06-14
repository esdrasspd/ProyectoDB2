using System.Reflection.Metadata.Ecma335;

namespace ProyectoDB2.DTOs
{
    public class ReporteCierreCajaDTO
    {
        public string NCliente { get; set; }
        public int RVentas { get; set; }
        public DateTime FCompras { get; set; }
        public decimal Stotal { get; set; }
        public decimal VTotal { get;set; }
    }
}
