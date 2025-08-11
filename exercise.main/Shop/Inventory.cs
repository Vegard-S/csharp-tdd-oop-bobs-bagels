using exercise.main.Shop.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Shop
{
    public class Inventory
    {
        public Dictionary<string, double> _inventory = new Dictionary<string, double>()
        {
            { "BGLO", 0.49 },
            { "BGLP", 0.39 },
            { "BGLE", 0.49 },
            { "BGLS", 0.49 },
            { "COFB", 0.99 },
            { "COFW", 1.19 },
            { "COFC", 1.29 },
            { "COFL", 1.29 },
            { "FILB", 0.12 },
            { "FILE", 0.12 },
            { "FILC", 0.12 },
            { "FILX", 0.12 },
            { "FILS", 0.12 },
            { "FILH", 0.12 }
        };
        

    }
}
