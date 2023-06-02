using System.Text.Json.Serialization;

namespace OngsLivesFront.MVC.Models
{
    public class Endereco
    {
        public Endereco()
        {
        }

        public Endereco(string? enderecoLinha, int numero, string? cep, string? bairro, string? cidade, string? estado, string? pais, string? latitude, string? longitude)
        {
            EnderecoLinha = enderecoLinha;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Latitude = latitude;
            Longitude = longitude;
        }

        [JsonIgnore]
        public int Id { get; set; }
        public string? EnderecoLinha { get; set; }
        public int Numero {get; set;}
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }
}