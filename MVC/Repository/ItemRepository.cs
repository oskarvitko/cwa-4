using MVC.Models;
using MVC.Repository;
using MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Repozitory
{
    public class ItemRepository : IItemRepository
    {
        public static List<Item> items = new List<Item>();
        public void Delete(int Id)
        {
            items = DB.Load();
            Item deleteble = items.Find(_item => _item.Id == Id);
            items.Remove(deleteble);
            DB.Save(items);
        }

        public List<Item> GetAll()
        {
            items = DB.Load();
            return items;
        }

        public Item GetById(int id)
        {
            items = DB.Load();
            return items.Find(_item => _item.Id == id);
        }

        public void Save(Item item)
        {
            items = DB.Load();
            items.Add(item);
            DB.Save(items);
        }

        public void Update(Item item)
        {
            items = DB.Load();
            Item updateble = items.FirstOrDefault(_item => _item.Id == item.Id);
            if (updateble != null)
            {
                updateble.Name = item.Name;
                updateble.Age = item.Age;
            }
            DB.Save(items);
        }
    }
}
