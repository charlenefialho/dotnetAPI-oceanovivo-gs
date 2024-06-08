using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OceanoVivo.Models
{
    public class Situacao
    {
        [Key]
        public int Id_Situacao { get; set; }

        [Required]
        [Column("Risco_Extincao")]
        public int Risco_ExtincaoInt { get; set; }

        [Required]
        [Column("Invasora")]
        public int InvasoraInt { get; set; }

        [NotMapped]
        public bool Risco_Extincao
        {
            get { return Risco_ExtincaoInt == 1; }
            set { Risco_ExtincaoInt = value ? 1 : 0; }
        }

        [NotMapped]
        public bool Invasora
        {
            get { return InvasoraInt == 1; }
            set { InvasoraInt = value ? 1 : 0; }
        }

        [JsonIgnore]
        public ICollection<Especie>? Especies { get; set; }
    }
}
