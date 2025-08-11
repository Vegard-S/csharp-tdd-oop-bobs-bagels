using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Shop
{
    public interface IProduct
    {
        int Id { get; set; }
        string SKU { get; set; }
        double Price { get; set; }
        string Name { get; set; }
        string Variant { get; set; }
    }
}
