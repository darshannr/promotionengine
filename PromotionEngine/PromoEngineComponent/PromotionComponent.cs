using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngineComponent
{
    public class PromotionComponent
    {
        private static List<Promotion> promotions = new List<Promotion>();

        public bool AddPromotion(char skuid, int quantity, float price)
        {
            int count = promotions.Count;
            promotions.Add(new Promotion { SKUID = skuid, Quantity = quantity, Price = price });
            if (promotions.Count > count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}