using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.Models
{
    public class DDD
    {
        [Key]
        public int DDDId { get; set; }

        [Required(ErrorMessage = "O nome do DDD é obrigatório")]
        [MaxLength(10)]
        public string Nome { get; set; }
        public ICollection<Contato> Contatos { get; set; }
    }
}
