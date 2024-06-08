using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanoVivo.Models
{
    public class Localizacao
    {
        [Key]
        public int Id_Localizacao { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public ICollection<Deteccao>? Deteccoes { get; set; }
    }
}
