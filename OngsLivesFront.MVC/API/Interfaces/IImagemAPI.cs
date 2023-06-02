using OngsLivesFront.MVC.Models;

namespace OngsLivesFront.MVC.API.Interfaces
{
    public interface IImagemAPI
    {
        Task<List<Imagem>> GetImagens();
        Task<Imagem> GetImagem(int id);
        Task<Imagem> CreateImagem(Imagem imagem);
        Task<bool> UpdateImagem(Imagem imagem);
        Task<bool> DeleteImagem(int id);
    }
}
