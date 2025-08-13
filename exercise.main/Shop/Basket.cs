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


    //filling price and discount
    public double NewBasketTotal() 
        {
            //help dictionary for the newBasketTotal to count number of types of a bagel
            Dictionary<string, int> bagelTypeCount = new Dictionary<string, int>()
            {
                { "BGLO", 0 },
                { "BGLP", 0 },
                { "BGLE", 0 },
                { "BGLS", 0 }
            };
            
            double result = 0;

            

            foreach (var item in _products)
            {
                if (item is Bagel bagel)
                {
                    //add all filling prices
                    result += bagel.FillingPrice;
                    //adding to the count of the bagel type
                    bagelTypeCount[bagel.SKU] += 1;
                    
                }
            }
            

            //assuming that only plain bagel gets the 12 discount, and the others get 6 discount. 6 discount for plain is more expensive than with no discount
            //also assuming it has to be the same bagel to get a discount
            foreach (var item in bagelTypeCount)
            {
                double discountPrice = 0;
                if (item.Key != "BGLP")
                {
                    //check number of small bagel discounts
                    int numSmallDiscount = item.Value / 6;
                    discountPrice = numSmallDiscount * 2.49;
                    bagelTypeCount[item.Key] -= numSmallDiscount * 6;
                }
                else if (item.Key == "BGLP")
                {
                    //check number of big bagel discounts
                    int numBigDiscount = item.Value / 12;
                    discountPrice = numBigDiscount * 3.99;
                    bagelTypeCount[item.Key] -= numBigDiscount * 12;
                }

                result += discountPrice;


            }


            //check coffee, if remainign bagels, apply coffe+bagel discount
            foreach (var item in _products)
            {
                if (item is Coffee coffee)
                {
                    
                    if (bagelTypeCount["BGLO"] > 0 )
                    {
                        //discount coffe + bagel
                        result += 1.25;
                        bagelTypeCount["BGLO"]--;
                    }
                    else if (bagelTypeCount["BGLE"] > 0)
                    {
                        //discount coffe + bagel
                        result += 1.25;
                        bagelTypeCount["BGLE"]--;
                    }
                    else if (bagelTypeCount["BGLS"] > 0)
                    {
                        //discount coffe + bagel
                        result += 1.25;
                        bagelTypeCount["BGLS"]--;
                    }
                    else if (bagelTypeCount["BGLP"] > 0)
                    {
                        //discount coffe + bagel
                        result += 1.25;
                        bagelTypeCount["BGLP"]--;
                    }
                    else
                    {
                        result += 0.99;
                    }
                }
            }
            foreach (var item in bagelTypeCount)
            {
                
                if (item.Value > 0)
                {
                    Console.WriteLine(item.Key);
                    result += ShowBagelPrice(item.Key);
                }
                
            }

            return result;
        }


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
