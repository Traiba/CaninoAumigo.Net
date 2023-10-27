using System.ComponentModel.DataAnnotations;

namespace CaninoAumigo_API.Models
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }

        [Required(ErrorMessage="O nome é obrigatório",AllowEmptyStrings=false)]
        [StringLength(20, ErrorMessage = "O tamanho máximo são 10 caracteres.")]
        public string? nome { get; set; }

        [Required(ErrorMessage="A sigla é obrigatório",AllowEmptyStrings=false)]
        [StringLength(2, ErrorMessage = "O tamanho máximo são 2 caracteres.")]
        public string? sigla { get; set; }

    }
}