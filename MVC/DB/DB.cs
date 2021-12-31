using MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace MVC
{
    public class DB
    {

        private static string path = "db.txt";

        public static void Save(List<Item> items)
        {
            File.Delete(path);
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Item item in items)
                {
                    writer.Write(item.Id);
                    writer.Write(item.Name);
                    writer.Write(item.Age);
                }
            }
        }

        public static List<Item> Load()
        {
            List<Item> items = new List<Item>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    string name = reader.ReadString();
                    int age = reader.ReadInt32();
                    items.Add(new Item(id, name, age));
                }
            }
            return items;
        }
    }
}
