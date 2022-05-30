using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class DetalheSessao
    {
        [Display(Name = "Detalhes da Sessão")]
        public int DetalheSessaoId { get; set; }

        [Required]
        [Display(Name = "Numero da Sala")]
        public int NumeroSala { get; set; }

        [Required]
        [Display(Name = "Quantidade de Lugares")]
        public int QuantidadeLugares { get; set; }

        [Required]       
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }



        [Required]
        [Display(Name = "Filme")]
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }

        [Required]
        [Display(Name = "Cadeira Selecionada")]
        public int CadeiraSelecionada { get; set; }

        
        
        [Required]
        [Display(Name = "Endereço")]
        
        public int SessaoId { get; set; }
        public Sessao Sessao { get; set; }


        
        [Required]
        [Display(Name = "Preço Total")]
        public int CompraId { get; set; }
        public Compra Compra { get; set; }
    }
}
