using SampleLoja.Apresentation.Interfaces;
using SampleLoja.Apresentation.Servicos;
using SampleLoja.Domain.Interfaces.Interface;
using SampleLoja.Domain.Interfaces.Repository;
using SampleLoja.Domain.Servicos;
using SampleLoja.Infra.Data.Contexto;
using SampleLoja.Infra.Data.Repositorios;
using SimpleInjector;

namespace SampleLoja.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegistarServicos(Container container)
        {
            //Registrar serviços para Injeção de dependência

            #region Registrar Serviços da Camada Aplicação
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            #endregion

            #region Registrar  Serviços da Camada Domonio
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            #endregion


            #region Registrar  Serviços da Camada Infra
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            #endregion


            #region Registrar  Serviços da Camada Infra Context
            container.Register<ProjetoModeloContexto>(Lifestyle.Scoped);
            #endregion

        }
    }
}
