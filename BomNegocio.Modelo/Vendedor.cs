using System.ComponentModel.DataAnnotations;

namespace BomNegocio.Modelo
{
    public class Vendedor
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
 
    }
}
