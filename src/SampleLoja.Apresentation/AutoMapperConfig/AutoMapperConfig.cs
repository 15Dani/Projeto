using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using SampleLoja.Apresentation.AutoMapperConfig.Profiles;

namespace SampleLoja.Apresentation.AutoMapperConfig
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

            //var all =

            //    Assembly

            //    .GetEntryAssembly()
            //    .GetReferencedAssemblies()
            //    .Select(Assembly.Load)
            //    .SelectMany(x => x.DefinedTypes)
            //    .Where(type => typeof(IProfile).GetTypeInfo().IsAssignableFrom(type.AsType()));

            //foreach (var ti in all)
            //{
            //    var t = ti.AsType();
            //    if (t.Equals(typeof(IProfile)))
            //    {
            Mapper.Initialize(x =>
            {
                x.AddProfile(typeof(ClienteProfile));
                        //  x.CreateMap<Cliente, ClienteViewModel>();
                        // x.CreateMap<Produto, ProdutoViewModel>();
                    });
            //    }
            //}
            //var profiles = from t in typeof(IProfile).Assembly.GetTypes()
            //    where typeof(IProfile).IsAssignableFrom(t) && typeof(IProfile) != t
            //               select t;

            ////add all profiles found to the MapperConfiguration
            //var config = new MapperConfiguration(cfg =>
            //{
            //    foreach (var profile in profiles)
            //    {
            //        cfg.AddProfiles(profile);
            //        //cfg.ShouldMapProperty = p =>
            //        //    p.GetMethod != null
            //        //    && (p.GetMethod.IsPublic || p.GetMethod.IsAssembly);


            //        //cfg.CreateMissingTypeMaps = true;


            //    }
            //});




        }
    }
}