using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiContacts.Domain.Recursos
{
    public class Paginacao
    {
        public int Pagina { get; set; } = 1;
        public int QuantidadePorPagina { get; set; } = 5;
    }
}
