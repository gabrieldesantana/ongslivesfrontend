using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API.Interfaces
{
    public interface IExperienciaAPI
    {
        Task<List<Experiencia>> GetExperiencias();
        Task<Experiencia> GetExperiencia(int id);
        Task<Experiencia> CreateExperiencia(Experiencia experiencia);
        Task<bool> UpdateExperiencia(Experiencia experiencia);
        Task<bool> DeleteExperiencia(int id);
    }
}
