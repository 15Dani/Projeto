using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SampleLoja.Domain.Interfaces.Repository
{
      //Classe ele como se fosse um classe, aqui embaixo eu faço meu CRUD
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        void Add(T obj);
        T GeT(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> BuscarPorFiltro(Expression<Func<T, bool>> filtro,
            Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> ordenacao,
            Expression<Func<T, object>>[] entidadesFilhas);
        void Update(T obj);
        void Remove(T obj);

        void Dispose();
    }
}
