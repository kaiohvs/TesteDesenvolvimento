using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvimento.Models;
using TesteDesenvolvimento.Repositorio;

namespace TesteDesenvolvimento.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _UsuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _UsuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = "Senha incorreto, tente novamente! ";
                    }

                    TempData["MensagemErro"] = "Login ou senha incorreto, tente novamente! ";

                }
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao acessar ao login, mensagem apresentada: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _UsuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrada com sucesso";
                    return RedirectToAction("Index");
                }
                
                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Usuario já existente, tente novamente! ";
                return RedirectToAction("Index");
            }
        }
    }

}


