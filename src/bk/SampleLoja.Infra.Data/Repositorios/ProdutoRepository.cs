using System.Collections.Generic;
using System.Linq;
using SampleLoja.Domain.Entidades;
using SampleLoja.Domain.Interfaces.Repository;

namespace SampleLoja.Infra.Data.Repositorios
{
    // O repository é generico , então não precisa daquilo tudo add, remove
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        //Buscar o produto
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Nomeproduto == nome);
        }
    }
}

