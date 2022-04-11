using TesteDesenvolvimento.Data;
using TesteDesenvolvimento.Models;

namespace TesteDesenvolvimento.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
                
            private readonly Contexto _contexto;

        public UsuarioRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();

            return usuario;
        }

        public Usuario Alterar(Usuario usuario)
        {
            Usuario alterarBD = ListarPorId(usuario.Id);

            if (alterarBD != null)
            {
                alterarBD.IdEmpresa = usuario.IdEmpresa;
                alterarBD.NomeUsuario = usuario.NomeUsuario;
                alterarBD.Senha = usuario.Senha;
                alterarBD.DocumentoUsuario = usuario.DocumentoUsuario;
                alterarBD.DataCriacao = usuario.DataCriacao;

                _contexto.Usuarios.Update(alterarBD);
                _contexto.SaveChanges();

                return alterarBD;
            }
            else
            {
                throw new Exception("Erro na atualização!");
            }

        }

        public Usuario ListarPorId(int id)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(e => e.Id == id);

            return usuario;
        }

        public List<Usuario> ListarTodos()
        {
            return _contexto.Usuarios?.ToList();
        }

        public bool ApagarUsuario(int id)
        {
            Usuario removeBD = ListarPorId(id);

            if (removeBD != null)
            {
                _contexto.Usuarios.Remove(removeBD);
                _contexto.SaveChanges();

                return true;
            }
            else
            {
                throw new Exception("Erro ao excluir empresa!");
            }
        }

        public Usuario BuscarPorLogin(string login)
        {
           return _contexto.Usuarios.FirstOrDefault(e => e.NomeUsuario.ToUpper() == login.ToUpper());
        }
    }
}
