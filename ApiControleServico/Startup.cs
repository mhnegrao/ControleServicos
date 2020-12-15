using ApiControleServico.Data;
using ApiControleServico.Services;
using DomainLib.Entidades;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiControleServico
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApiControleServicoContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("ExitoDBUOLConnection")));
            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBaseEntity, BaseEntity>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IEnderecoService, EnderecoService>();
            services.AddTransient<IDocumentoService, DocumentoService>();
            services.AddTransient<IOrcamentoService, OrcamentoService>();
            services.AddTransient<IOrdemServicoService, OrdemServicoService>();
            services.AddTransient<IOrdemServicoItemService, OrdemServicoItemService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}