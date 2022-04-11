using TesteDesenvolvimento.Models;

namespace TesteDesenvolvimento.Repositorio
{
    public interface IUsuarioRepositorio
    {
        public Usuario BuscarPorLogin(string login);
        public Usuario Adicionar(Usuario usuario);
        public List<Usuario> ListarTodos();

        public Usuario ListarPorId(int id);

        public Usuario Alterar(Usuario empresa);

        public bool ApagarUsuario(int id);

    }
}
