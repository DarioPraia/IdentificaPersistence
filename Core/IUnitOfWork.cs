using IdentificaPersistence.Core.Repositories;

namespace IdentificaPersistence.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IIdentificacaoRepository Identificacoes { get; }

        int Complete();
    }
}