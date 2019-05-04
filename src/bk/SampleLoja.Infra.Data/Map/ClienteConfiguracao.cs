using System.Data.Entity.ModelConfiguration;
using SampleLoja.Domain.Entidades;

namespace SampleLoja.Infra.Data.Map
{
    // essa classe será a manipulação de alguma coisa que quero fazer no cadastro cliente
   public class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
    {
        // estou passando o tamanho para meu banco de dados, conforme minha tabela
        public ClienteConfiguracao()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired();
                
        }
    }
}
