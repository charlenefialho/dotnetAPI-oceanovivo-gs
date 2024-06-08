using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanoVivo.Models
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public string Genero { get; set; }

        public ICollection<Deteccao>? Deteccoes { get; set; }
    }
}
