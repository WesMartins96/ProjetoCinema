using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Sessao
    {

        public int SessaoId { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Numero da Sala")]
        public int Salas { get; set; }
    }
}
