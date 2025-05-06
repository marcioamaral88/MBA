using BomNegocio.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace BomNegocio.Web.Configuration
{
    public static class DatabaseSelectorExtension
    {
        public static void AddDatabaseSelector(this WebApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<BomNegocioContexto>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionLite")));

               }
            else
            {
                builder.Services.AddDbContext<BomNegocioContexto>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

             }

        }
    }
}
