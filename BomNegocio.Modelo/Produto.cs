using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BomNegocio.Modelo
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }
              
        [Column(TypeName = "VARCHAR(50)")]
        public string Codigo { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Range(0, int.MaxValue, ErrorMessage = "O preço não pode ser negativo.")]
        public decimal Preco { get; set; }
              
        [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo.")]
        public int Estoque { get; set; }

        [Column(TypeName = "VARCHAR(250)")]
        public string ProdutoImagem { get; set; }
   
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
 
        [ForeignKey("Vendedor")]
        public string VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}

