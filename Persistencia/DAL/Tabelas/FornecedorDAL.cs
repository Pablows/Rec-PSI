using Modelo.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Tabelas
{
    public class FornecedorDAL
    {
        private EFContext context = new EFContext(); //public talvez

        public IQueryable<Fornecedor> ObterFornecedoresClassificadasPorNome()
        {
           return context.Fornecedores.OrderBy(b => b.Nome);
        }

        public Fornecedor ObterFornecedorPorId(long id)
        {
            return context.Fornecedores.Where(c => c.IdFornecedor == id).First();
        }

        public void GravarFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor.IdFornecedor == 0)
            {
                context.Fornecedores.Add(fornecedor);
            }
            else
            {
                context.Entry(fornecedor).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Fornecedor EliminarFornecedorPorId(long id)
        {
            Fornecedor fornecedor = ObterFornecedorPorId(id);
            context.Fornecedores.Remove(fornecedor);
            context.SaveChanges();
            return fornecedor;
        }
    }
}
