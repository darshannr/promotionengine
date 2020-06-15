using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngineComponent
{
    public class ProductComponent
    {
        private static List<Product> products = new List<Product>();

        public bool AddProduct(char skuid, float price)
        {
            int count = products.Count;
            products.Add(new Product { SKUID = skuid, Price = price });
            if (products.Count > count)
            {
                return true;
            }
            else
            { return false; }
        }

        public bool RemoveProduct(char skuid)
        {
            int count = products.Count;
            Product product = products.Where(x => x.SKUID == skuid).FirstOrDefault();
            products.Remove(product);
            if (products.Count < count)
            {
                return true;
            }
            else
            { return false; }
        }
    }
}