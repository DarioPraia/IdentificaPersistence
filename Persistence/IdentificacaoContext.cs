using IdentificaPersistence.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace IdentificaPersistence.Persistence
{
    public class IdentificacaoContext : DbContext
    {
        public virtual DbSet<Pessoa> Pessoas { get; set; }

        public virtual DbSet<Identificacao> Identificacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=L3091DBI21\MSSQLSERVER_NEW;Database=Identificacao;Trusted_Connection=True;User=developer;Password=Dapr4573d4s;");
        }
    }
}