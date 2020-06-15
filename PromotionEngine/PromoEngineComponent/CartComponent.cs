using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngineComponent
{
    public class CartComponent
    {
        private List<Cart> cartList = new List<Cart>();

        public bool AddCart(char skuid, int quantity, List<Product> productList, List<Promotion> promosList)
        {
            int count = cartList.Count;
            cartList.Add(new Cart
            {
                SKUID = skuid,
                quantity = quantity,
                Price = GetPrice(skuid, quantity, productList, promosList)
            });
            if (cartList.Count > count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private float GetPrice(char skuid, int quantity, List<Product> productList, List<Promotion> promosList)
        {
            float price = 0;

            bool IsExists = promosList.Where(x => x.SKUID == skuid).Count() > 0 ? true : false;
            if (IsExists)
            {
                Promotion promo = new Promotion();
                Product product = new Product();
                promo = promosList.Where(x => x.SKUID == skuid).FirstOrDefault();
                product = productList.Where(x => x.SKUID == skuid).FirstOrDefault();

                if (quantity >= promo.Quantity)
                {
                    int i = quantity;
                    while (i >= promo.Quantity)
                    {
                        price += promo.Price;
                        i = i - promo.Quantity;
                    }
                    price += i * product.Price;
                }
                else
                {
                    price = product.Price * quantity;
                }
            }
            return price;
        }

        public float GetCartTotal(List<Product> productList, List<Promotion> promosList)
        {
            float total = 0;
            int count = cartList.Where(x => x.SKUID == 'C' || x.SKUID == 'D').Count();
            if (count >= 2)
            {
                cartList = cartList.Select(x =>
                {
                    if (x.SKUID == 'C') x.Price = 0;
                    return x;
                }).ToList();
            }
            else
            {
                cartList = cartList.Select(x =>
                {
                    if (x.SKUID == 'C') x.Price = productList.Where(y=>y.SKUID == 'C').Select(y=>y.Price).First() *x.quantity;
                    return x;
                }).ToList();
                cartList = cartList.Select(x =>
                {
                    if (x.SKUID == 'D') x.Price = productList.Where(y => y.SKUID == 'D').Select(y => y.Price).First() * x.quantity;
                    return x;
                }).ToList();

            }
            total = cartList.Sum(x => x.Price);
            return total;
        }
    }
}