using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvimento.Models;
using TesteDesenvolvimento.Repositorio;

namespace TesteDesenvolvimento.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _UsuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<Usuario> usuario = _UsuarioRepositorio.ListarTodos();
            return View(usuario);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Usuario usuario)
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
                TempData["MensagemErro"] = $"Erro ao cadastrar o usuario, mensagem apresentada: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {

            Usuario usuario = _UsuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Alterar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _UsuarioRepositorio.Alterar(usuario);
                    TempData["MensagemSucesso"] = "Usuario editada com sucesso! ";
                    return RedirectToAction("Index");
                }               
                    return View("Editar", usuario);                
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao alterar o usuario, mensagem apresentada: {ex.Message}";
                return RedirectToAction("index");
            }
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            Usuario usuario = _UsuarioRepositorio.ListarPorId(id);

            return View(usuario);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                _UsuarioRepositorio.ApagarUsuario(id);
                TempData["MensagemSucesso"] = "Usuario apagada com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["MensagemErro"] = $"Erro ao apagar o usuario, mensagem apresentada: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
