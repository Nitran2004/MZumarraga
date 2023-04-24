using MessagePack;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace MZumarraga.Models
{
    public class MZumarraga

    {
        [Key]
        [Display(Name = "Número MZ")]
        [Required(ErrorMessage = "El campo Número MZ es obligatorio.")]
        public int EANumero { get; set; }

        [Display(Name = "Decimal MZ")]
        [Range(0, 100, ErrorMessage = "El campo Decimal MZ debe estar entre 0 y 100.")]
        public decimal EADecimal { get; set; }

        [Display(Name = "Texto MZ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El campo Texto EA debe tener al menos 3 caracteres.")]
        public string EAString { get; set; }

        [Display(Name = "Booleano MZ")]
        public bool EABool { get; set; }

        [Display(Name = "Fecha  MZ")]
        [DataType(DataType.Date)]
        public DateTime EAFecha { get; set; }

    }
}
