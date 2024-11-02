using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contacts.Domain.ModelsView
{
    public class DDDViewUpdateModel
    {
        public int DDDId { get; set; }
        public int Ddd { get; set; }
        public string Nome { get; set; }
    }
}
