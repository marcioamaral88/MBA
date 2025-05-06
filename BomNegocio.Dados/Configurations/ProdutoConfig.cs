using BomNegocio.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BomNegocio.Dados.Configurations
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(500);
            builder.Property(p => p.Codigo).HasMaxLength(50);
            builder.Property(p => p.Preco).HasColumnType("decimal(12,2)").IsRequired();
            builder.Property(p => p.Estoque).IsRequired();
            builder.Property(p => p.ProdutoImagem).HasColumnType("VARCHAR(250)");
            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Vendedor)
                .WithMany(v => v.Produtos)
                .HasForeignKey(p => p.VendedorId)
                .OnDelete(DeleteBehavior.Restrict); 

        }
    }
}


