using System.Collections.Generic;
using SampleLoja.Domain.Entidades;

namespace SampleLoja.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
