using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Models
{
    public class Livro
    {
        public Livro(string codigo, string nome, string autor, decimal preco)
        {
            Codigo = codigo;
            Nome = nome;
            Autor = autor;
            Preco = preco;
        }

        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }

        
    }
}
