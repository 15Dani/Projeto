using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SampleLoja.Domain.Entidades;

namespace SampleLoja.Domain.Interfaces.Interface
{
    public interface  IClienteService : IDisposable
    {
        IEnumerable<Cliente> BuscarPorFiltro(Expression<Func<Cliente, bool>> filtro = null,
            Expression<Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>>> ordenacao = null,
            params Expression<Func<Cliente, object>>[] entidadesFilhas);
    }
}
