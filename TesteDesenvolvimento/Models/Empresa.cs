using System.ComponentModel.DataAnnotations;

namespace TesteDesenvolvimento.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Por favor, preencha o nome da empresa! ")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a documentação da empresa! ")]
        public string DocumentoEmpresa { get; set; }        
        public DateTime DataCriacao { get; set; }
       

    }
}
