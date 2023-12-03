namespace BackEnd.Models
{
    public class AutomovilModel
    {
        public int Id { get; set; }
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int Anio { get; set; }
        public string Placa { get; set; } = null!;
        public int Disponibilidad { get; set; }
        public int Precio { get; set; }
        public DateTime FechaActualizado { get; set; }
        public int IdCategorias { get; set; }
        public int IdDeSedes { get; set; }
        public int IdSeguros { get; set; }
    }
}
