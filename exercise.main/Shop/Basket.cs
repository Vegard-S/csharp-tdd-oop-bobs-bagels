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
        private int _capacity;
        private double _basketTotal;
        public List<IProduct> _products;
        Dictionary<int, IProduct> _inventory = new Dictionary<int, IProduct>()
{
    { 1, new Bagel ( 1, "BGLO", 0.49, "Bagel", "Onion" ) },
    { 2, new Bagel(2, "BGLP", 0.39, "Bagel", "Plain") },
    { 3, new Bagel(3, "BGLE", 0.49, "Bagel", "Everything") },
    { 4, new Bagel(4, "BGLS", 0.49, "Bagel", "Sesame") },
    { 5, new Coffee(5, "COFB", 0.99, "Coffee", "Black") },
    { 6, new Coffee(6, "COFW", 1.19, "Coffee", "White") },
    { 7, new Coffee(7, "COFC", 1.29, "Coffee", "Capuccino") },
    { 8, new Coffee(8, "COFL", 1.29, "Coffee", "Latte") },
    { 9, new Filling(9, "FILB", 0.12, "Filling", "Bacon") },
    { 10, new Filling(10, "FILE", 0.12, "Filling", "Egg") },
    { 11, new Filling(11, "FILC", 0.12, "Filling", "Cheese") },
    { 12, new Filling(12, "FILX", 0.12, "Filling", "Cream Cheese") },
    { 13, new Filling(13, "FILS", 0.12, "Filling", "Smoked Salmon") },
    { 14, new Filling(14, "FILH", 0.12, "Filling", "Ham") }

};


        public bool Add(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
        public bool CheckFull()
        {
            throw new NotImplementedException();
        }
        public bool ChangeCapacity(int capacity)
        {
            throw new NotImplementedException();
        }
        public bool CheckIfExists(int id)
        {
            throw new NotImplementedException();
        }
        public double BasketTotal()
        {
            throw new NotImplementedException();
        }
        public double ShowBagelPrice(int id)
        {
            throw new NotImplementedException();
        }
        public double ShowFillingPrice(int id)
        {
            throw new NotImplementedException();
        }
        public bool CheckInventory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
