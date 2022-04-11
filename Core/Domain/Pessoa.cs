using System.ComponentModel.DataAnnotations.Schema;

namespace IdentificaPersistence.Core.Domain
{
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DataNasecimento { get; set; }

        public string NomePai { get; set; }

        public string NomeMae { get; set; } 

        public int Idade { get { return (DateTime.Now.Year - DataNasecimento.Year); } }
    }
}