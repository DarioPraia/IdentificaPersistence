using IdentificaPersistence.Core.Domain;

namespace IdentificaPersistence.Core.Repositories
{
    public interface IIdentificacaoRepository : IRepository<Identificacao>
    {
        Identificacao GetIdentificacaoPeloNumero(string numero);
    }
}