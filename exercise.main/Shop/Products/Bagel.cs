using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Shop.Products
{
    public class Bagel : IProduct
    {
        public Bagel(int id, string sKU, double price, string name, string variant)
        {
            Id = id;
            SKU = sKU;
            Price = price;
            Name = name;
            Variant = variant;
        }


        public int Id { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public List<IProduct> Fillings = new List<IProduct>();

        public double FillingPrice { get { return Fillings.Sum(x => x.Price); } }
        public bool AddFilling(IProduct filling)
        {
            Fillings.Add(filling);
            return true;
        }
    }
}
