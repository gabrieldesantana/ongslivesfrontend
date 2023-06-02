using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API.Interfaces
{
    public interface IOngFinanceiroAPI
    {
        Task<List<OngFinanceiro>> GetOngFinanceiros();
        Task<OngFinanceiro> GetOngFinanceiro(int id);
        //Task<OngFinanceiro> CreateOngFinanceiro(OngFinanceiro ongFinanceiro);
        Task<bool> UpdateOngFinanceiro(OngFinanceiro ongFinanceiro);
        Task<bool> DeleteOngFinanceiro(int id);
    }
}
