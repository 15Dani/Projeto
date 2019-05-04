using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using SampleLoja.Domain.Interfaces.Repository;
using SampleLoja.Infra.Data.Contexto;

namespace SampleLoja.Infra.Data.Repositorios
{
   public class RepositoryBase<T> :  IRepositoryBase<T> where T : class
    {

        // Pega o meu dados do contexto e faça as condições abaixo, de acordo com o meu objeto
        protected ProjetoModeloContexto Db = new ProjetoModeloContexto();
        private bool _isDisposed;
        public void Add(T obj)
        {
            Db.Set<T>().Add(obj);
            Db.SaveChanges();
        }

        public T GeT(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Db.Set<T>().ToList();
        }

        public void update(T obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(T obj)
        {
            Db.Set<T>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    // Clear down managed resources.

                    if (Db != null)
                    {
                        Db.Dispose();
                        GC.SuppressFinalize(this);
                    }


                }

                _isDisposed = true;
            }
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> BuscarPorFiltro(Expression<Func<T, bool>> filtro = null, 
            Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> ordenacao = null, 
            params Expression<Func<T, object>>[] entidadesFilhas)
        {
            try
            {
                IQueryable<T> query = Db.Set<T>();

                /*Pasamos as entidades filhas que queremos da classe T que foi passado
                 * E ai incluímos usando o método Include para o EF pesquisar.
                 */
                foreach (Expression<Func<T, object>> filhas in entidadesFilhas)
                    query = query.Include(filhas);

                /* Valida se foi passado algo para filtra na sua consulta
                 * Se sim ele vai trazer os dados conforme o filtro
                 */
                if (filtro != null)
                    query = query.Where(filtro);


                /* Valida se foi passado algo para se ordenado na sua consulta
               * Se sim ele vai trazer os dados com ordenação default do seu banco
               */
                if (ordenacao != null)
                    query = ordenacao.Compile()(query);


                /*Caso não passou nada nesses parâmetro ele vai trazer tudo.
             */
                return query;


            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }

            return null;
        }
    }
}
