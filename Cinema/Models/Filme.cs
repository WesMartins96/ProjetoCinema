using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Filme
    {
        public int FilmeId { get; set; }

        [Required]
        [Display(Name = "Filme")]
        public string NomeFilme { get; set; }

        [Required]
        [Display(Name = "Idade Indicativa")]
        public int Idadeindicativa { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public string GeneroFilme { get; set; }

        [Required]
        public string Sinopse { get; set; }

    }
}
