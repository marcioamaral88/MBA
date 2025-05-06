using BomNegocio.Dados.Contexto;
using BomNegocio.Modelo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BomNegocio.Web.Configurations
{
    public static class DbMigrationHelperExtension
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelpers.EnsureSeedData(app).Wait();
        }
    }

    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<BomNegocioContexto>();

            if (env.IsDevelopment() || env.IsEnvironment("Docker") || env.IsStaging())
            {
                await context.Database.MigrateAsync();

                await EnsureSeedProducts(context);
            }
        }

        private static async Task EnsureSeedProducts(BomNegocioContexto context)
        {
            if (context.Categoria.Any())
                return;

            await context.Categoria.AddRangeAsync(new Categoria()
            {
                Id = 1,
                Nome = "Automotivo"

            });

            await context.Categoria.AddRangeAsync(new Categoria()
            {
                Id = 2,
                Nome = "Moradia"
            });

            await context.Categoria.AddRangeAsync(new Categoria()
            {
                Id = 3,
                Nome = "Roupas e Calçados"
            });
            await context.Categoria.AddRangeAsync(new Categoria()
            {
                Id = 4,
                Nome = "Cama, mesa e banho",
            });

            await context.SaveChangesAsync();

            if (context.Users.Any())
                return;

            var idUser = Guid.NewGuid().ToString();

            await context.Users.AddAsync(new IdentityUser
            {
                Id = idUser,
                UserName = "mba@mba.com",
                NormalizedUserName = "MBA@MBA.COM",
                Email = "mba@mba.com",
                NormalizedEmail = "MBA@MBA.COM",
                AccessFailedCount = 0,
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEEdWhqiCwW/jZz0hEM7aNjok7IxniahnxKxxO5zsx2TvWs4ht1FUDnYofR8JKsA5UA==",
                TwoFactorEnabled = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            });

            await context.SaveChangesAsync();

            await context.Vendedor.AddAsync(new Vendedor()
            {
                Id = idUser,
                Nome = "mba@mba.com"
            });

            await context.SaveChangesAsync();


            if (context.Produto.Any())
                return;

            await context.Produto.AddAsync(new Produto()
            {
                Nome = "Gol Msi 1.6 Automático 2021",
                VendedorId = idUser,
                Descricao = "Gol Msi 1.6 Automático \r\n46 mil km rodados\r\nPagamento à vista no pix, dinheiro, cartão ou financiamento\r\nBateria moura com garantia até 14/01/2026\r\nTroca de óleo em dia\r\nAlinhado e balanceado \r\nMultimídia original do carro com car play\r\nCom manual e chave reserva\r\nCarro bem conservado\r\nRodas originais de liga leve diamantadas\r\nTeto e retrovisores plotado de black piano\r\nFreios ABS\r\nSensores de estacionamento traseiro\r\nFaróis com refletores duplos e de neblina",
                CategoriaId = 1,
                Estoque = 2,
                Preco = 200000,
                ProdutoImagem = "/images/produtos/gol.webp"
            });

            await context.Produto.AddAsync(new Produto()
            {
                Nome = "Corolla Cross XRX hybrid 2022",
                VendedorId = idUser,
                Descricao = "Vendo Corolla Cross 2021-22 em estado impecável. Modelo XRX híbrido top de linha, com teto solar. Sistema de segurança ADAS completo. Licenciamento pago!!! Próximo vencimento somente em outubro de 2025!! Na garantia de fábrica. Revisão de 50.000 km ja realizada na",
                CategoriaId = 1,
                Estoque = 2,
                Preco = 15800000,
                ProdutoImagem = "/images/produtos/corola.webp"
            });

            await context.Produto.AddAsync(new Produto()
            {
                Nome = "RANGER LTZ diesel 4x4",
                VendedorId = idUser,
                Descricao = "S-10 LTZ Aut 2020\r\nCompletinha\r\nÚnico dono\r\nRevisada na concessionária \r\nFipe 157\r\n\r\n?VALOR R$139.900,00",
                CategoriaId = 1,
                Estoque = 1,
                Preco = 2200000,
                ProdutoImagem = "/images/produtos/Ranger.webp"
            });

            await context.Produto.AddAsync(new Produto()
            {
                Nome = "Vendo Pajero Full 4x4 - 7 lugares",
                VendedorId = idUser,
                Descricao = " Farol com Retrofit BiLed 120.000 Lumes (2.500,00 reais investidos);\r\n? Farol de Milha BiLed 150.000 Lumes (2.000,00 reais investidos);\r\n? Farol Alto Duplo com mais de 150.000 Lumes 5;\r\n? Multimedia com Apple CarPlay e Android Auto sem fio; e painel reformado.\r\n? 5 Pneus ? Novos;\r\n? 4 Amortecedores novos;\r\n? Troca de óleo a cada 5 mil km, Filtro de óleo, óleo original  no motor a cada troca;",
                CategoriaId = 1,
                Estoque = 2,
                Preco = 22000000,
                ProdutoImagem = "/images/produtos/pajero.webp"
            });

            await context.Produto.AddAsync(new Produto()
            {
                Nome = "Vendo Pajero Full 4x4 - 7 lugares",
                VendedorId = idUser,
                Descricao = " Farol com Retrofit BiLed 120.000 Lumes (2.500,00 reais investidos);\r\n? Farol de Milha BiLed 150.000 Lumes (2.000,00 reais investidos);\r\n? Farol Alto Duplo com mais de 150.000 Lumes 5;\r\n? Multimedia com Apple CarPlay e Android Auto sem fio; e painel reformado.\r\n? 5 Pneus ? Novos;\r\n? 4 Amortecedores novos;\r\n? Troca de óleo a cada 5 mil km, Filtro de óleo, óleo original  no motor a cada troca;",
                CategoriaId = 1,
                Estoque = 2,
                Preco = 22000000,
                ProdutoImagem = "/images/produtos/pajero2.webp"
            });

            await context.Produto.AddAsync(new Produto()
            {
                Nome = "RENAULT KWID OUTSIDER 2 2024",
                VendedorId = idUser,
                Descricao = "Gol Msi 1.6 Automático \r\n46 mil km rodados\r\nPagamento à vista no pix, dinheiro, cartão ou financiamento\r\nBateria moura com garantia até 14/01/2026\r\nTroca de óleo em dia\r\nAlinhado e balanceado \r\nMultimídia original do carro com car play\r\nCom manual e chave reserva\r\nCarro bem conservado\r\nRodas originais de liga leve diamantadas\r\nTeto e retrovisores plotado de black piano\r\nFreios ABS\r\nSensores de estacionamento traseiro\r\nFaróis com refletores duplos e de neblina",
                CategoriaId = 1,
                Estoque = 2,
                Preco = 6800000,
                ProdutoImagem = "/images/produtos/kwid.webp"
            });

            await context.Produto.AddAsync(new Produto()
            {
                Nome = "sandero",
                VendedorId = idUser,
                Descricao = "sandero",
                CategoriaId = 1,
                Estoque = 2,
                Preco = 2000000,
                ProdutoImagem = "/images/produtos/sandero.webp"
            });

            await context.SaveChangesAsync();


        }
    }
}
