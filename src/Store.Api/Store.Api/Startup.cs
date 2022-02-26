using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Store.Api.Middleware;
using Store.Dominio.Entidades;
using Store.Persistencia;
using Store.Repositorios;
using Store.Repositorios.Interfaces;
using Store.Servicio.Queries;
using Store.Servicio.Queries.Dto;
using Store.Servicio.Queries.Interfaces;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Store.Api
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
            // Inyeccion Contexto de seguridad 
            var builder = services.AddIdentityCore<Usuario>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<SeguridadDbContext>();
            builder.AddSignInManager<SignInManager<Usuario>>();
            


            var secretKey = Encoding.ASCII.GetBytes(
            Configuration.GetValue<string>("SecretKey")
);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            //Automaper

            services.AddAutoMapper(typeof(MappingProfiles));
            //
            services.AddMediatR(Assembly.Load("Store.Servicio.EventHandler"));

            //Interfaces Logica de negocios


            services.AddTransient<IProductoQueryService, ProductoQueryService>();
            services.AddTransient<IMarcaQueryService, MarcaQueryService>();
            services.AddTransient<ICategoriaQueryService, CategoriaQueryService>();

            // Interfaces Repositorios

            services.AddTransient<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped(typeof(IGenericRepositorio<>),(typeof(GenericRepositorio<>)));
            //Conexion


            

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConexionDB"));
            });

            services.AddDbContext<SeguridadDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConexionDBIdentity"));
            });


            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsRule", rule =>
                {
                    rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("");
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "E- Carvajal Store", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store.Api v1"));
            }


            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors", "?code={0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsRule");

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
