using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Models
{
    public class Relatorio : IRelatorio
    {
        private readonly ICatalogo catalogo;

        public Relatorio(ICatalogo catalogo)
        {
            this.catalogo = catalogo;
        }

        public async Task ImprimirAsync(HttpContext context)
        {
            foreach (var livro in catalogo.GetLivros())
            {
                await context.Response.WriteAsync($"{livro.Codigo,-10}.{livro.Nome,-40} -{livro.Autor}-{livro.Preco.ToString("c"),10}\r\n");
            }

        }
    }
}
