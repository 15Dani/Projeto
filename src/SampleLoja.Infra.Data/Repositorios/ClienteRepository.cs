using SampleLoja.Domain.Entidades;
using SampleLoja.Domain.Interfaces.Repository;

namespace SampleLoja.Infra.Data.Repositorios
{
    // Herdado os repositoris
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {

    }
}
