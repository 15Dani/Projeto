using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SampleLoja.Apresentation.ViewModels;

namespace SampleLoja.Apresentation.Interfaces
{
    public interface IClienteAppService : IDisposable
    {

        /*Bom esse é nosso filtro genérico depois você estuda esses aqui: Expression,  Func, IQueryable, IOrderedQueryable
         * params, para ver mais opções e fica mais familiarizada com o código. Eu vou explicar como funciona
         * e como você vai conseguir montar suas consultas e as possíbilidades nesse código ai.
         * 
           Bom basicamente temos 3 parâmetros nesse método
         * No primeiro podemos passar uma consulsta parecido com o where, ous  seja, ai vamos informar o que queremos
         * trazer do BD, tipo se quiser trazer alguma cliente por id, então é nesse parâmetro que vamos informar.
         * Calma que vou explicar como fazer isso ok?ta, No segundo, esse serve para trazer os dados por ordem só fazer isso 
         * ou seja digamos que desejamos trazer o cliente por nome, cidade, uf, etc, seria esse ai para fazer isso.
         * O última eses serve para trazermos alguma classe que esteja relacionado a cliente.
         * Digamos que queremos trazer todos os produtos dos clientes, então é nesse parâmetro que vamos fazer
         * Fico um pouco mais claro o que cada um faz?:
         * sim e que estou lendors ok vou deixar esse texto para você lembrar, qai quando pegar o jeito pode tirar eses
         * comentários por que são má práticas no código e fica bagunçado coloco produto embaixo
         */
        IEnumerable<ClienteViewModel> BuscarPorFiltro(Expression<Func<ClienteViewModel, bool>> filtro = null,
            Expression<Func<IQueryable<ClienteViewModel>, IOrderedQueryable<ClienteViewModel>>> ordenacao = null,
            params Expression<Func<ClienteViewModel, object>>[] entidadesFilhas);

        

    }
}
