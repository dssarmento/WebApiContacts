using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Contacts.Domain.Models;

namespace Contacts.Domain.ModelsView
{
    public class ContatoRetornoView
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int DDDId { get; set; }
    }
}
