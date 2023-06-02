using OngsLivesFront.MVC.API.Interfaces;
using OngsLivesFront.MVC.API;
using OngsLivesFront.MVC.Helpers;
using OngsLivesFront.MVC.Repository;

namespace OngsLivesFront.MVC.Ioc
{
    public static class DependecyContainer
    {
        public static void AddRegisterServices(this IServiceCollection services)
        {
            #region Sessao

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ISessao, Sessao>();

            services.AddSession(x =>
            {
                x.Cookie.HttpOnly = true;
                x.Cookie.IsEssential = true;
            });

            #endregion

            #region Repository

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region Consumo API

            services.AddHttpClient<IVoluntarioAPI, VoluntarioAPI>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7185/");
            });

            services.AddHttpClient<IOngAPI, OngAPI>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7185/");
            });

            services.AddHttpClient<IVagaAPI, VagaAPI>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7185/");
            });

            services.AddHttpClient<IExperienciaAPI, ExperienciaAPI>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7185/");
            });

            services.AddHttpClient<IOngFinanceiroAPI, OngFinanceiroAPI>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7185/");
            });

            services.AddHttpClient<IUsuarioAPI, UsuarioAPI>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7185/");
            });

            services.AddHttpClient<IImagemAPI, ImagemAPI>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7185/");
            });

            #endregion
        }
    }
}
