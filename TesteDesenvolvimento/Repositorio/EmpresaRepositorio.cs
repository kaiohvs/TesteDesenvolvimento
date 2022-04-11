using TesteDesenvolvimento.Data;
using TesteDesenvolvimento.Models;

namespace TesteDesenvolvimento.Repositorio
{    
        public class EmpresaRepositorio : IEmpresaRepositorio
        {
            private readonly Contexto _contexto;

            public EmpresaRepositorio(Contexto contexto)
            {
                _contexto = contexto;
            }

            public Empresa Adicionar(Empresa empresa)
            {
                _contexto.Empresas.Add(empresa);
                _contexto.SaveChanges();

                return empresa;
            }

        public Empresa Alterar(Empresa empresa)
        {
            Empresa alterarBD = ListarPorId(empresa.Id);

            if(alterarBD != null)
            {
                alterarBD.NomeEmpresa = empresa.NomeEmpresa;
                alterarBD.DocumentoEmpresa = empresa.DocumentoEmpresa;
                alterarBD.DataCriacao = empresa.DataCriacao;

                _contexto.Empresas.Update(alterarBD);
                _contexto.SaveChanges();

                return alterarBD;
            }
            else
            {
                throw new Exception("Erro na atualização!");
            }

        }

        public Empresa ListarPorId(int id)
        {
            var empresa = _contexto.Empresas.FirstOrDefault(e => e.Id == id);

            return empresa;
        }

        public List<Empresa> ListarTodos()
        {
            return _contexto.Empresas?.ToList();
        }

        public bool ApagarEmpresa(int id)
        {
            Empresa removeBD = ListarPorId(id);

            if(removeBD != null)
            {
                _contexto.Empresas.Remove(removeBD);
                _contexto.SaveChanges();

                return true;
            }
            else
            {
                throw new Exception("Erro ao excluir empresa!");
            }
        }
    }
    }



