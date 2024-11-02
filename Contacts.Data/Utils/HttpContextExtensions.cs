using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Data.Context;

namespace Contacts.Data.Utils
{
    public static class HttpContextExtensions
    {
        public async static Task InserirParametroEmPageResponse<T>(HttpContext context,
           IQueryable<T> queryable, int quantidadeTotalRegistrosAExibir)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            double quantidadeRegistrosTotal = await queryable.CountAsync();
            double totalPaginas = Math.Ceiling(quantidadeRegistrosTotal / quantidadeTotalRegistrosAExibir);

            //salvando as informações no header do response
            context.Response.Headers.Add("quantidadeRegistrosTotal", quantidadeRegistrosTotal.ToString());
            context.Response.Headers.Add("totalPaginas", totalPaginas.ToString());
        }
    }
}
