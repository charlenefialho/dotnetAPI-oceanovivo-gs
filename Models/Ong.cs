using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanoVivo.Models
{
    public class Ong
    {
        [Key]
        public int Id_Ong { get; set; }

        [Required]
        [StringLength(18)]
        public string Cnpj { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Telefone { get; set; }

        public ICollection<OngDeteccao>? OngDeteccoes { get; set; }
    }
}
