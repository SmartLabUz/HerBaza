using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerBaza
{
    public class Item
    {
        public Item(string name,string sureName, string phone)
        {
            Name = name;
            SureName = sureName;
            Phone = phone;
        }
        public Item()
        {
        }
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Phone { get; set; }
        public DateTime Day { get; set; } = DateTime.Now;
    }
}
