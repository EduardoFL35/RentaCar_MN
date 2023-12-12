namespace FrontEnd.Models
{
    public class TransaccioneViewModel
    {

        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int CostoTotal { get; set; }
        public string Detalles { get; set; } = null!;
        public DateTime ShipmentDate { get; set; }
        public int IdAutomovil { get; set; }
        public IEnumerable<AutomovileViewModel> Automoviles { get; set; }
        public int IdCliente { get; set; }
        public IEnumerable<ClienteViewModel> Clientes { get; set; }
        public int IdEmpleado { get; set; }
        public IEnumerable<EmpleadoViewModel> Empleados { get; set; }

    }
}
