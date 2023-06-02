using System.Text.Json.Serialization;

namespace OngsLivesFront.MVC.Models
{
    public class Experiencia : Base
    {
        public Experiencia()
        {
        }
        public Experiencia(
            string? nomeVoluntario,
            string? nomeOng,
            string? projetoEnvolvido,
            string? opiniao,
            DateTime dataExperienciaInicio,
            DateTime dataExperienciaFim,
            int nota)
        {
            NomeVoluntario = nomeVoluntario;
            NomeOng = nomeOng;
            ProjetoEnvolvido = projetoEnvolvido;
            Opiniao = opiniao;
            DataPostagem = DateTime.Now;
            DataExperienciaInicio = dataExperienciaInicio;
            DataExperienciaFim = dataExperienciaFim;
            CriadoEm = DateTime.Now;
            Nota = nota;
        }

        // public int Id { get; set; }
        public int IdVoluntario { get; set; }
        public Voluntario? Voluntario { get; set; }
        public int IdOng { get; set; }
        public Ong? Ong { get; set; }

        public string? NomeVoluntario { get; set; }
        public string? NomeOng { get; set; }
        public string? ProjetoEnvolvido { get; set; }
        public string? Opiniao { get; set; }
        public int Nota { get; set; }
        public DateTime DataPostagem { get; set; }
        public DateTime DataExperienciaInicio{ get; set; }
        public DateTime DataExperienciaFim { get; set; }
        [JsonIgnore]
        public DateTime CriadoEm { get; set; }
    }
}