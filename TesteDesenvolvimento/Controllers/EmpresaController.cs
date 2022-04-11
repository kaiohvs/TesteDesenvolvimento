using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvimento.Models;
using TesteDesenvolvimento.Repositorio;


namespace TesteDesenvolvimento.Controllers
{
    
    public class EmpresaController : Controller
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;

        public EmpresaController(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        public IActionResult Index()
        {
            List<Empresa> empresa = _empresaRepositorio.ListarTodos();
            return View(empresa);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {

            Empresa empresa = _empresaRepositorio.ListarPorId(id);
            return View(empresa);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            Empresa empresa = _empresaRepositorio.ListarPorId(id);

            return View(empresa);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _empresaRepositorio.ApagarEmpresa(id);
                TempData["MensagemSucesso"] = "Empresa apagada com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["MensagemErro"] = $"Erro ao apagar a empresa, mensagem apresentada: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(Empresa empresa)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _empresaRepositorio.Adicionar(empresa);
                    TempData["MensagemSucesso"] = "Empresa cadastrada com sucesso";                    
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(empresa);
                }

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar a empresa, mensagem apresentada: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empresaRepositorio.Alterar(empresa);
                    TempData["MensagemSucesso"] = "Empresa editada com sucesso! ";                   
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Editar", empresa);
                }
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao alterar a empresa, mensagem apresentada: {ex.Message}";
                return RedirectToAction("index");
            }
        }
    }
}
