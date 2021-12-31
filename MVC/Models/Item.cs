using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    [Serializable]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Item(int Id, string Name, int Age)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
        }
    }
}
