using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OceanoVivo.Models
{
    public class Categoria
    {
        [Key]
        public int Id_Categoria { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Habitat { get; set; }
        public string Reino { get; set; }
        public string Familia { get; set; }

        [JsonIgnore]
        public ICollection<Especie>? Especies { get; set; }
    }
}
