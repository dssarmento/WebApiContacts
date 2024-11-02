using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.Models
{
    public class Contato
    {
        [Key]
        public int ContatoId { get; set; }

        [Required(ErrorMessage = "O nome do Contato é obrigatório")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Telefone do Contato é obrigatório")]
        [MaxLength(10)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O E-Mail do Contato é obrigatório")]
        [MaxLength(150)]
        public string Email { get; set; }

        public int DDDId { get; set; }

        public virtual DDD DDD { get; set; }
    }
}
