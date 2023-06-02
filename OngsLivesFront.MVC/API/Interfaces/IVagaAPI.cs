using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API.Interfaces
{
    public interface IVagaAPI
    {
        Task<List<Vaga>> GetVagas();
        Task<Vaga> GetVaga(int id);
        Task<Vaga> CreateVaga(Vaga vaga);
        Task<bool> UpdateVaga(Vaga vaga);
        Task<bool> DeleteVaga(int id);
    }
}
