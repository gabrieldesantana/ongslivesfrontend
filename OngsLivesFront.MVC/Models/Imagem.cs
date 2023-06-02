namespace OngsLivesFront.MVC.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public int IdDono { get; set; }
        public string? Nome { get; set; }
        public byte[]? Conteudo { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Actived { get; set; }
    }
}
