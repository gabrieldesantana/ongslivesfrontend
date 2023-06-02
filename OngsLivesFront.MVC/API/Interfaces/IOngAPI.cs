using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API.Interfaces
{
    public interface IOngAPI
    {
        Task<List<Ong>> GetOngs();
        Task<Ong> GetOng(int id);
        Task<Ong> GetOngByEmail(string email);
        Task<Ong> CreateOng(Ong ong);
        Task<bool> UpdateOng(Ong ong);
        Task<bool> DeleteOng(int id);
    }
}
