namespace BackEnd.Models
{
    public class TransaccionModel
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int CostoTotal { get; set; }
        public string Detalles { get; set; } = null!;
        public DateTime ShipmentDate { get; set; }
        public int IdAutomovil { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
    }
}
