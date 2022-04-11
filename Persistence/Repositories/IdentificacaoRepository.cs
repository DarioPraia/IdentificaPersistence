using IdentificaPersistence.Core.Domain;
using IdentificaPersistence.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IdentificaPersistence.Persistence.Repositories
{
    public class IdentificacaoRepository : Repository<Identificacao>, IIdentificacaoRepository
    {
        public IdentificacaoRepository(DbContext context) : base(context)
        {
        }

        public Identificacao GetIdentificacaoPeloNumero(string numero)
        {
            Identificacao identificacao =  IdentificacaoContext.Identificacoes.Include("Pessoa").First(i => i.Numero == numero);

            // identificacao.Pessoa = IdentificacaoContext.Pessoas.First(p => p.Id == identificacao.Pessoa.Id);

            return identificacao;
        }

        public IdentificacaoContext IdentificacaoContext
        {
            get { return Context as IdentificacaoContext; }
        }
    }
}