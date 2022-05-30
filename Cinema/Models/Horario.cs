using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Horario
    {

        public int HorarioId { get; set; }

        [Required]
        [Display(Name = "Horario da Sessão")]
        public DateTime HorarioSessao { get; set; }

    }
}
