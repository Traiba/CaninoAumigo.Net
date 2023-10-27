using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CaninoAumigo_API.Models

{
      public class Conta
    {
        [Key]
        public int? idConta { get; set; }

        public string? senha { get; set; }
        public string? cpf { get; set; }

        public string? nome { get; set; }

        public string? telefone { get; set; }

        public string? email { get; set; }

        public string? endereco { get; set; }
        public int? idade { get; set; }
        public int idCidade { get; set; }
        public string? imagem { get; set; }

    }
}