//biblioteca para o DataAnnotations
using System.ComponentModel.DataAnnotations;
//namespace 
namespace CaninoAumigo_API.Models
{
    //classe animaç
    public class Animal
    {
        //identificando primary key
        [Key]
        public int? idAnimal { get; set; }

        //required, campo obrigatório, tamanho suportado de até 30 caracteres 
        [Required(ErrorMessage = "O nome do animal é obrigatório", AllowEmptyStrings = false)]
        [StringLength(30, ErrorMessage = "O tamanho máximo são 30 caracteres.")]
        //campo nome do bd
        public string? nome { get; set; }
        //required, campo obrigatório, tamanho suportado de até 30 caracteres 
        [Required(ErrorMessage = "A raça do animal é obrigatória", AllowEmptyStrings = false)]
        [StringLength(30, ErrorMessage = "O tamanho máximo são 30 caracteres.")]
        //campo raca do bd
        public string? raca { get; set; }
        //required, campo obrigatório, tamanho suportado de até 20 caracteres 
        [Required(ErrorMessage = "A cor do animal é obrigatória", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "O tamanho máximo são 20 caracteres.")]

        //campo cor do bd
        public string? cor { get; set; }

        //required, campo obrigatório, alcance de numero de 0 a 99
        [Required(ErrorMessage = "A idade do animal é obrigatória", AllowEmptyStrings = false)]
        [Range(0, 99)]
        //campo idade do bd
        public int? idade { get; set; }
        //campo descricao do bd
        public string? descricao { get; set; }
        //required, campo obrigatório, tamanho suportado de até 11 caracteres 
        [Required(ErrorMessage = "O gênero do animal é obrigatório", AllowEmptyStrings = false)]
        [StringLength(11, ErrorMessage = "O tamanho máximo são 11 caracteres.")]
        //campo genero do bd
        public string? genero { get; set; }
        //required, campo obrigatório, tamanho suportado de até 200 caracteres 
        [Required(ErrorMessage = "O status de vacinação do animal é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "O tamanho máximo são 11 caracteres.")]
        //campo vacinacao do bd
        public string? vacinacao { get; set; }
        //campo idPorte do bd
        public int idPorte { get; set; }
        //campo idCidade do bd
        public int idCidade { get; set; }
        //campo imagem do bd
        public string? imagem { get; set; }
    }
}