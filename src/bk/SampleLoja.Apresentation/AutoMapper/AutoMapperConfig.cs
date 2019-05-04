using System.Linq;
using System.Reflection;
using AutoMapper;

namespace SampleLoja.Apresentation.AutoMapper
{
    public static class AutoMapperConfig
    {
        
        public static void RegisterMappings()
        {
            // Mapper.Initialize( x => 
            //{ 
            // x.AddProfile<DomainToViewModelMappingProfile>();
            //x.AddProfile<ViewModelToDomainMappingProfile>();

            // });

            //Nesse aqui ele já vai pegar todas as classes que tiver o IProfile,e já vai registrar automaticamente,

            var all =

                Assembly

                .GetEntryAssembly()
                .GetReferencedAssemblies()
                .Select(Assembly.Load)
                .SelectMany(x => x.DefinedTypes)
                .Where(type => typeof(IProfile).GetTypeInfo().IsAssignableFrom(type.AsType()));

            foreach (var ti in all)
            {
                var t = ti.AsType();
                if (t.Equals(typeof(IProfile)))
                {
                    Mapper.Initialize(x =>
                    {
                        x.AddProfiles(t);
                        //  x.CreateMap<Cliente, ClienteViewModel>();
                        // x.CreateMap<Produto, ProdutoViewModel>();
                    });
                }
            }



        }
    }
}