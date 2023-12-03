namespace BackEnd.Models
{
    public class SedeModel
    {
        public int Id { get; set; }
        public string NombreUbi { get; set; } = null!;
        public string? Provincia { get; set; }
        public string Ciudad { get; set; } = null!;
        public string DireccionSede { get; set; } = null!;
    }
}
