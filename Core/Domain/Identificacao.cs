using System.ComponentModel.DataAnnotations.Schema;

namespace IdentificaPersistence.Core.Domain
{
    public class Identificacao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Numero { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}