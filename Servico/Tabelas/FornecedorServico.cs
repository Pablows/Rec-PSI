using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;

namespace Servico.Tabelas
{
    public class FornecedorServico
    {
        private FornecedorDAL fornecedorDAL = new FornecedorDAL();

        public IQueryable<Fornecedor> ObterFornecedoresClassificadasPorNome()
        {
            return fornecedorDAL.ObterFornecedoresClassificadasPorNome();
        }

        public Fornecedor ObterFornecedoresPorId(long id)
        {
            return fornecedorDAL.ObterFornecedorPorId(id);
        }

        public void GravarFornecedor(Fornecedor fornecedor)
        {
            fornecedorDAL.GravarFornecedor(fornecedor);
        }

        public Fornecedor EliminarFornecedorPorId(long id)
        {
            Fornecedor fornecedor = fornecedorDAL.ObterFornecedorPorId(id);
            fornecedorDAL.EliminarFornecedorPorId(id);
            return fornecedor;
        }
    }
}
