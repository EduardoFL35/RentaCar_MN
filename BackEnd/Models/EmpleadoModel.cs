namespace BackEnd.Models
{
    public class EmpleadoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaContratacion { get; set; }
        public int IdSede { get; set; }
    }
}
