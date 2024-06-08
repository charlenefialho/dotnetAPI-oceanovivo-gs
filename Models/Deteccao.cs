using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OceanoVivo.Models
{
    public class Deteccao
    {
        [Key]
        public int Id_Deteccao { get; set; }

        [Required]
        [Url]
        public string Url_Imagem { get; set; }

        [Required]
        public DateTime Data_Deteccao { get; set; }

        [ForeignKey("Usuario")]
        public int Id_Usuario { get; set; }
        [JsonIgnore]
        public Usuario Usuario { get; set; }

        [ForeignKey("Localizacao")]
        public int Id_Localizacao { get; set; }
        [JsonIgnore]
        public Localizacao Localizacao { get; set; }

        [ForeignKey("Especie")]
        public int Id_Especie { get; set; }
        [JsonIgnore]
        public Especie Especie { get; set; }

        [JsonIgnore]
        public ICollection<OngDeteccao> OngDeteccoes { get; set; }
    }

    public class OngDeteccao
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Ong")]
        public int OngId { get; set; }
        [JsonIgnore]
        public Ong Ong { get; set; }

        [ForeignKey("Deteccao")]
        public int DeteccaoId { get; set; }
        [JsonIgnore]
        public Deteccao Deteccao { get; set; }
    }
}
