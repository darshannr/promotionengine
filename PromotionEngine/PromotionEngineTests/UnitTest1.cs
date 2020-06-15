using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PromoEngineComponent;

namespace PromotionEngineTests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void AddToProduct()
        {
            ProductComponent product = new ProductComponent();
            Assert.AreEqual(true, product.AddProduct('A', 50));
            Assert.AreEqual(true, product.AddProduct('B', 30));
            Assert.AreEqual(true, product.AddProduct('C', 20));
            Assert.AreEqual(true, product.AddProduct('D', 15));
        }

        [TestMethod]
        public void AddPromotion()
        {
            PromotionComponent promotions = new PromotionComponent();
            Assert.AreEqual(true, promotions.AddPromotion('A', 3, 130));
            Assert.AreEqual(true, promotions.AddPromotion('B', 2, 45));
            Assert.AreEqual(true, promotions.AddPromotion('C', 1, 30));
            Assert.AreEqual(true, promotions.AddPromotion('D', 1, 30));
        }

        [TestMethod]
        public void AddToCart()
        {
            CartComponent cart = new CartComponent();
            Assert.AreEqual(true, cart.AddCart('A', 1));
            Assert.AreEqual(true, cart.AddCart('B', 1));
            Assert.AreEqual(true, cart.AddCart('C', 1));
            Assert.AreEqual(100, cart.GetCartTotal());
        }

        //[TestMethod]
        //public void RemoveFromProduct()
        //{
        //    ProductComponent product = new ProductComponent();
        //    Assert.AreEqual(true, product.RemoveProduct('A'));
        //    Assert.AreEqual(true, product.AddProduct('A', 50));
        //}

        //[TestMethod]
        //public void GetTotal()
        //{
        //    PromotionEngineComponent pec = new PromotionEngineComponent();
        //    List<Cart> cartList = new List<Cart>();
        //    cartList.Add(new Cart
        //    {
        //        SKUID = 'A',
        //        Quantity = 1,
        //        SKUPrice = 0
        //    });
        //    float result = pec.GetTotal();
        //    Assert.Equals(result, GetTotal(cartList));
        //}
    }
}