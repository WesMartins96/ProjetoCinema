using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Compra
    {

        public int CompraId { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public double Valor { get; set; }

        [Display(Name = "Meia Entrada")]
        public bool IsMeia { get; set; }

        [Display(Name = "Promoção Especial")]
        public bool PromocaoEspecial { get; set; }

    }
}
