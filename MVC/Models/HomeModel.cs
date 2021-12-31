using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class HomeModel
    {
        public List<Item> items;
        public Item item;

        public HomeModel(List<Item> items, Item item)
        {
            this.items = items;
            this.item = item;
        }
    }
}
