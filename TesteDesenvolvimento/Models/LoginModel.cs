using System.ComponentModel.DataAnnotations;

namespace TesteDesenvolvimento.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Dgite o Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Dgite a senha")]
        public string Senha { get; set; }
    }
}
