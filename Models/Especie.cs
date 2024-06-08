using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OceanoVivo.Models
{
    public class Especie
    {
        [Key]
        public int Id_Especie { get; set; }

        [Required]
        public string Nome_Comum { get; set; }

        [Required]
        public string Nome_Cientifico { get; set; }

        public string Descricao { get; set; }

        [ForeignKey("Categoria")]
        public int Id_Categoria { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

        [ForeignKey("Situacao")]
        public int Id_Situacao { get; set; }

        [JsonIgnore]
        public Situacao? Situacao { get; set; }

        public ICollection<Deteccao>? Deteccoes { get; set; }
    }
}
