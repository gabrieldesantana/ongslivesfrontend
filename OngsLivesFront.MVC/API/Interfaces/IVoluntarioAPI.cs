using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API.Interfaces
{
    public interface IVoluntarioAPI
    {
        Task<List<Voluntario>> GetVoluntarios();
        Task<Voluntario> GetVoluntario(int id);
        Task<Voluntario> GetVoluntarioByEmail(string email);
        Task<Voluntario> CreateVoluntario(Voluntario voluntario);
        Task<bool> UpdateVoluntario(Voluntario voluntario);
        Task<bool> DeleteVoluntario(int id);
    }
}
