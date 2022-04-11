using IdentificaPersistence.Core;
using IdentificaPersistence.Core.Repositories;
using IdentificaPersistence.Persistence.Repositories;

namespace IdentificaPersistence.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentificacaoContext _context;
        public IIdentificacaoRepository Identificacoes { get; private set;}

        public UnitOfWork(IdentificacaoContext context)
        {
            _context = context;

            Identificacoes = new IdentificacaoRepository(_context);

            _context.Database.EnsureCreated();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}