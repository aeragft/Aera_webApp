using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Models.ViewModels
{
    public class ChartViewModel
    {
        public ChartViewModel(IList<ItemOrder> itens)
        {
            Itens = itens;
        }

        public IList<ItemOrder> Itens { get; }

        public decimal Total => Itens.Sum(i => i.Quantity * i.UniValue);
    }
}
