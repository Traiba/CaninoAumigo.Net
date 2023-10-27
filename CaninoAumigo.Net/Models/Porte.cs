using System.ComponentModel.DataAnnotations;

namespace CaninoAumigo_API.Models
{
    public class Porte
    {
        [Key]
        public int idPorte { get; set; }

        [Required(ErrorMessage="O tamanho é obrigatório",AllowEmptyStrings=false)]
        [StringLength(10, ErrorMessage = "O tamanho máximo são 10 caracteres.")]
        public string? tamanho { get; set; }

    }
}