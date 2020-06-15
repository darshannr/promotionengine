using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngineComponent
{
    public class CartComponent
    {
        private static List<Cart> cartList = new List<Cart>();

        public bool AddCart(char skuid, int quantity)
        {
            int count = cartList.Count;

            return true;
        }

        public float GetCartTotal()
        {
            return 100;
        }
    }
}