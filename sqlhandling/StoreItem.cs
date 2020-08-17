using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.sqlhandling
{
    class StoreItem
    {
        private int id;
        private String name;
        private double price;

        public StoreItem(int id,String name,double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
        public double Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }
}
