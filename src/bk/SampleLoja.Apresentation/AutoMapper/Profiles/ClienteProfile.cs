using AutoMapper;
using SampleLoja.Apresentation.ViewModels;
using SampleLoja.Domain.Entidades;

namespace SampleLoja.Apresentation.AutoMapper.Profiles
{
  public   class ClienteProfile : Profile, IProfile
    {
        public ClienteProfile()
        {
            /*Nessa linha fala o seguinte o que vier do banco a classe Cliente vai 
               jogar o valor que tiver em ClienteId => Codigo.
               E ainda adicionei um método que faz parte do AutoMapper 8 que fazer o processo
               reverso, no caso se você passar um valor na view e quando for jogar no BD 
               o mapeamento vai identificar que Na ClienteVM tem um mapeamento onde Codigo => CienteId
               devido esse método ReverseMap();
               Simples?
               s50 *6ss6 fazer 5ss6 *ra t6d6s? srs
                */
            CreateMap<Cliente, ClienteViewModel>()                               
                .ReverseMap();
        }

        
    }
}
