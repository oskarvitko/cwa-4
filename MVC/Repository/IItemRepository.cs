using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Repository
{
    interface IItemRepository
    {
        public List<Item> GetAll();
        public Item GetById(int id);
        public void Update(Item item);
        public void Delete(int id);
        public void Save(Item item);
    }
}
