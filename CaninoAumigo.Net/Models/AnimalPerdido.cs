using System.ComponentModel.DataAnnotations;

namespace CaninoAumigo_API.Models
{
    public class AnimalPerdido
    {
        [Key]
        public int? idAnimalPerdido { get; set; }

        public string? nome { get; set; }
        
        public string? telefone { get; set; }

        public string? email { get; set; }

        public string? complemento { get; set; }

        public int idCidade { get; set; }

        public string? imagem { get; set; }
    }
}