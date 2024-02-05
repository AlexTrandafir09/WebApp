using WebApp.Repositories.BazaRepository;
using WebApp.Repositories.Echipa_ligaRepository;
using WebApp.Repositories.EchipaRepository;
using WebApp.Repositories.JucatorRepository;
using WebApp.Repositories.LigaRepository;
using WebApp.Services.BazaService;
using WebApp.Services.Echipa_ligaService;
using WebApp.Services.EchipaService;
using WebApp.Services.JucatorService;
using WebApp.Services.LigaService;
using WebApp.Services.UserService;

namespace WebApp.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddTransient<IRepository, Repository>();
            services.AddTransient<IBazaRepository, BazaRepository>();
            services.AddTransient<IEchipaRepository, EchipaRepository>();
            services.AddTransient<IEchipa_ligaRepository, Echipa_ligaRepository>();
            services.AddTransient<IJucatorRepository, JucatorRepository>();
            services.AddTransient<ILigaRepository, LigaRepository>();


            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddTransient<IService,Service>();
            services.AddTransient<IBazaService, BazaService>();
            services.AddTransient<IEchipaService, EchipaService>();
            services.AddTransient<IEchipa_ligaService,Echipa_ligaService>();
            services.AddTransient<IJucatorService,JucatorService>();
            services.AddTransient<ILigaService,LigaService>();
            services.AddTransient<IUserService, UserService>();



            return services;
        }
    }
}
