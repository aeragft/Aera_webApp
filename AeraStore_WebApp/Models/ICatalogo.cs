using System.Collections.Generic;

namespace AeraStore_WebApp.Models
{
    public interface ICatalogo
    {
        List<Livro> GetLivros();
    }
}