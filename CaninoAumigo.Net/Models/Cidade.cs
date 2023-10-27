using System.ComponentModel.DataAnnotations;

namespace CaninoAumigo_API.Models
{
    public class Cidade
    {
        [Key]
        public int idCidade { get; set; }

        [Required(ErrorMessage="O nome é obrigatório",AllowEmptyStrings=false)]
        [StringLength(15, ErrorMessage = "O tamanho máximo são 10 caracteres.")]
        public string? nome { get; set; }

        [Required(ErrorMessage="A sigla é obrigatório",AllowEmptyStrings=false)]
        [StringLength(2, ErrorMessage = "O tamanho máximo são 2 caracteres.")]

        public int idEstado { get; set; }
    }
}