namespace BackEnd.Models
{
    public class MantenimientoModel
    {
        public int Id { get; set; }
        public string TipoMantenimiento { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public int Costo { get; set; }
        public string DescripcionMantenimiento { get; set; } = null!;
        public int Estado { get; set; }
        public DateTime FechaActualizado { get; set; }
        public int IdAutomovil { get; set; }
    }
}
