using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Models
{
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro("001", "Livros Teste MVC", "Aceitando Aulas", 24.89m));
            livros.Add(new Livro("002", "Criando WebApp MVC", "Alura Cursos", 30.99m));
            livros.Add(new Livro("003", "Arturando dotnet", "Ce Sharp", 50.99m));

            return livros;
        }
    }
}
