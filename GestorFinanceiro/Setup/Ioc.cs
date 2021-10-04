using Data.Interfaces;
using Data.Repositories;
using GestorFinanceiro.CommandHandle;
using GestorFinanceiro.ICommandHandle;
using GestorFinanceiro.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GestorFinanceiro.Setup
{
    public static class Ioc
    {
        public static void AddSetup(this IServiceCollection services)
        {
            services.AddScoped<IEnvioDeEmailService, EnvioDeEmailService>();

            services.AddScoped<ILoginCommandHandle, LoginCommandHandle>();
            services.AddScoped<ICriarUsuarioCommandHandle, CriarUsuarioCommandHandle>();
            services.AddScoped<IEditarUsuarioCommandHandle, EditarUsuarioCommandHandle>();
            services.AddScoped<IExcuirUsuarioCommandHandle, ExcluirUsuárioCommandHandle>();
            services.AddScoped<IAtivarUsuarioCommandHandle, AtivarUsuarioCommandHandle>();
            services.AddScoped<ICriarCategoriaCommandHandle, CriarCategoriaCommandHandle>();
            services.AddScoped<IEditarCategoriaCommandHandle, EditarCategoriaHandle>();
            services.AddScoped<IExcluirCategoriaCommandHandle, ExcluirCategoriaCommandHandle>();
            services.AddScoped<ICriarReceitaCommandHandle, CriarReceitaCommandHandle>();


            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IReceitaRepository, ReceitaRepository>();
        }
    }
}
