using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using SampleLoja.Domain.Entidades;
using SampleLoja.Infra.Data.Contexto;

namespace SampleLoja.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class
        Configuration : DbMigrationsConfiguration<SampleLoja.Infra.Data.Contexto.ProjetoModeloContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ProjetoModeloContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //Set the randomizer seed if you wish to generate repeatable data sets.

            //Set the randomizer seed if you wish to generate repeatable data sets.
            Randomizer.Seed = new Random(8675309);
            var clienteIds = 0;
            var produtoIds = 0;

            
            var produtoFaker = new Faker<Produto>("pt_BR")
                //.RuleFor(o => o.Id, produtoIds++)
                // Ensure all properties have rules. By default, StrictMode is false
                //Set a global policy by using Faker.DefaultStrictMode
                //.StrictMode(true)
                .RuleFor(o => o.Id, f=> produtoIds++)
                 .RuleFor(o => o.Disponivel, f => f.Random.Bool())
                .RuleFor(o => o.Nomeproduto, f => f.Commerce.Product())
                .RuleFor(o => o.Valorproduto, f => f.Random.Decimal(min: 10, max: 100));


            var clienteFaker = new Faker<Cliente>("pt_BR")
                .RuleFor(o => o.Id, f => clienteIds++)
                .RuleFor(o => o.Nome, f => f.Person.FirstName)
                .RuleFor(o => o.Sobrenome, f => f.Person.LastName)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.Produtos, f => produtoFaker.Generate(10).ToList())
                .RuleFor(o => o.DataCadastro, f => f.Date.Future());


            var clientesList = clienteFaker.Generate(20);
            //var produtosList = produtoFaker.Generate(6).ToList();

            //foreach (var cliente in clientesList)
            //{


            //    foreach (var produto in produtosList)
            //    {
            //        produto.Id = produtoIds++;
            //        cliente.Produtos.Add(produto);
            //    }

            //    context.Clientes.Add(cliente);
            //}
            //produtosList.ForEach(p => clientesList.ForEach(c => c.Produtos.Add(p)));
            context.Clientes.AddRange(clientesList);

            context.SaveChanges();


            return;

            //
        }
    }
}