using TesteDesenvolvimento.Models;

namespace TesteDesenvolvimento.Repositorio
{
    public interface IEmpresaRepositorio
    {
        public Empresa Adicionar(Empresa empresa);

        public List<Empresa> ListarTodos();

        public Empresa ListarPorId(int id);

        public Empresa Alterar(Empresa empresa);

        public bool ApagarEmpresa(int id);
    }
}
