using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var allProducts = new SortedDictionary<string, Dictionary<string, double>>();
            var input = Console.ReadLine();
            while (input != "Revision")
            {
                var productInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string shop = productInfo[0];
                var product = productInfo[1];
                var price = double.Parse(productInfo[2]);
                if (allProducts.TryAdd(shop, new Dictionary<string, double> ()))
                {                    
                }
                allProducts[shop][product] = price;
                input = Console.ReadLine();
            }
            foreach (var item in allProducts)
            {
                Console.WriteLine($"{item.Key}->");
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
