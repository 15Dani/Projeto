using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using SampleLoja.Domain.Entidades;
using SampleLoja.Infra.Data.Map;

namespace SampleLoja.Infra.Data.Contexto
{
    //Classe pronta para receber o contexto, intalado o pacote Enity
    public class ProjetoModeloContexto : DbContext
    {
        public ProjetoModeloContexto()
            : base("ProjetoModeloDDD")
        {
            this.Configuration.LazyLoadingEnabled = false;
            
        }

        // Pega os dados do meu cliente, após isso inserir o conect string
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ele não vai ficar plurazindo as tabelas pq ele não entende o portugues
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Não vai remover em cascata quando tiver relação de 1 pra muitos
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Não vai remover por cascata.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Ensina ele entender que meu ID e minha chave primaria, se o nome 
            // tiver ID no final ela é primary Key
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            // retirando o nvarchar das tabelas
            modelBuilder.Properties<string>()
            .Configure(p => p.HasColumnType("varchar"));


            //dizer o tamanho da string
            modelBuilder.Properties<string>()
              .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguracao());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());

        }

        // não fica setando toda vez a data cadastro, acha a propriedade e ver se ela existe
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                } 
            } return base.SaveChanges();
        }
        

    }
     
}
