using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SampleLoja.Domain.Entidades;
using SampleLoja.Domain.Interfaces.Interface;
using SampleLoja.Domain.Interfaces.Repository;

namespace SampleLoja.Domain.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IEnumerable<Cliente> BuscarPorFiltro(Expression<Func<Cliente, bool>> filtro = null, Expression<Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>>> ordenacao = null, params Expression<Func<Cliente, object>>[] entidadesFilhas)
        {
            return _clienteRepository.BuscarPorFiltro(filtro, ordenacao, entidadesFilhas);
        }
        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
