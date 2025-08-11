using exercise.main.Shop.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Shop
{
    public class Basket
    {
        private int _capacity = 2;
        public List<IProduct> _products = new List<IProduct>();
        private Inventory _inventory = new Inventory();




        public bool Add(IProduct product)
        {
            if (!CheckFull())
            {
                _products.Add(product);
                return true;
            }
            else 
            {
                Console.WriteLine("basket is full!");
                return false; 
            }
            
        }

        public bool Remove(IProduct product)
        {
            foreach (var item in _products)
            {
                if (item.Id == product.Id)
                {
                    _products.Remove(item);
                    return true;
                }
            }
            Console.WriteLine("Product is now in basket, not removed");
            return false;
        }
        public bool CheckFull()
        {
            if (_products.Count >= _capacity)
            {
                //true means full
                return true;
            }
            else 
            { 
                return false; 
            }
        }
        public bool ChangeCapacity(int capacity)
        {
            //possible add manager check as if statement and return false if not manager
            _capacity = capacity;
            return true;
        }


        public double BasketTotal { get { return _products.Sum(x => x.Price); } }
        public double ShowBagelPrice(string SKU)
        {
            if (SKU == "BGLO" || SKU == "BGLP" || SKU == "BGLE" || SKU == "BGLS")
            {
                return _inventory._inventory[SKU];
            }
            else
            {
                Console.WriteLine("product is not bagel");
                return 0;
            }
        }
        public double ShowFillingPrice(string SKU)
        {
            if (SKU == "FILB" || SKU == "FILE" || SKU == "FILC" || SKU == "FILX" || SKU == "FILS" || SKU == "FILH")
            {
                return _inventory._inventory[SKU];
            }
            else
            {
                Console.WriteLine("product is not filling");
                return 0;
            }
        }
        public bool CheckInventory(string SKU)
        {
            if (_inventory._inventory.ContainsKey(SKU))
            {
                return true;
            }
            return false;
        }
    }
}
