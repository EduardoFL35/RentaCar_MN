namespace BackEnd.Models
{
    public class SeguroModel
    {
        public int Id { get; set; }
        public string TipoSeguro { get; set; } = null!;
        public int CostoSeguro { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
