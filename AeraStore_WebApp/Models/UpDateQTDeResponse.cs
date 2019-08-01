using AeraStore_WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Models
{
    public class UpDateQTDeResponse
    {
        public UpDateQTDeResponse(ItemOrder itemOrder, ChartViewModel chartViewModel)
        {
            ItemOrder = itemOrder;
            ChartViewModel = chartViewModel;
        }

        public ItemOrder ItemOrder { get; }

        public ChartViewModel ChartViewModel { get; }
    }
}
