using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SampleLoja.Apresentation.Interfaces;
using SampleLoja.Apresentation.ViewModels;
using SampleLoja.Domain.Entidades;
using SampleLoja.Domain.Interfaces.Interface;

namespace SampleLoja.Apresentation.Servicos
{
    public class ClienteAppService : ApplicationService, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        //produto agora temos o método para fazer nossa lógica de trazer o cliente no BD
        public IEnumerable<ClienteViewModel> BuscarPorFiltro(Expression<Func<ClienteViewModel, bool>> filtro = null, 
            Expression<Func<IQueryable<ClienteViewModel>, IOrderedQueryable<ClienteViewModel>>> ordenacao = null,
            params Expression<Func<ClienteViewModel, object>>[] entidadesFilhas)
        {
            var mapFilter = Mapper.Map<Expression<Func<Cliente, bool>>>(filtro);
            var mapOrdenacao = Mapper.Map<Expression<Func<IQueryable<Cliente>, IOrderedQueryable<Cliente> >>>(ordenacao);
            var mapEntidadesFilhas = Mapper.Map<Expression<Func<Cliente, object>>[]>(entidadesFilhas);
            return Mapper.Map<IEnumerable<ClienteViewModel>>(
                _clienteService.BuscarPorFiltro(mapFilter, mapOrdenacao, mapEntidadesFilhas));
        }

       
        public void Dispose()
        {
            
                _clienteService.Dispose();
                GC.SuppressFinalize(this);
            
        }

        


    }
}
