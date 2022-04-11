using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDesenvolvimento.Models
{
    public class Usuario
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o nome do usuario! ")]       
        public string NomeUsuario { get; set; }
        [Required(ErrorMessage = "Por favor, preencha a senha de usuario! ")]        
        [StringLength(10, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 3 e 10 caracteres")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Por favor, preencha a documentacao do usuario! ")]
        public string DocumentoUsuario { get; set; }
        public DateTime DataCriacao { get; set; }

        [ForeignKey("Empresa")]
        public int ?IdEmpresa { get; set; }
        public Empresa ?Empresa { get; set; }
        
        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
       


    }
}
