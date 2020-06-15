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
            List<Product> productList = new List<Product>();
            List<Promotion> promotionList = new List<Promotion>();
            productList.Add(new Product { SKUID = 'A', Price = 50 });
            productList.Add(new Product { SKUID = 'B', Price = 30 });
            productList.Add(new Product { SKUID = 'C', Price = 20 });
            productList.Add(new Product { SKUID = 'D', Price = 15 });

            promotionList.Add(new Promotion { SKUID = 'A', Quantity = 3, Price = 130 });
            promotionList.Add(new Promotion { SKUID = 'B', Quantity = 2, Price = 45 });
            promotionList.Add(new Promotion { SKUID = 'C', Quantity = 1, Price = 30 });
            promotionList.Add(new Promotion { SKUID = 'D', Quantity = 1, Price = 30 });

            CartComponent cart = new CartComponent();
            Assert.AreEqual(true, cart.AddCart('A', 1, productList, promotionList));
            Assert.AreEqual(true, cart.AddCart('B', 1, productList, promotionList));
            Assert.AreEqual(true, cart.AddCart('C', 1, productList, promotionList));
            Assert.AreEqual(100, cart.GetCartTotal(productList, promotionList));

            cart = new CartComponent();
            Assert.AreEqual(true, cart.AddCart('A', 5, productList, promotionList));
            Assert.AreEqual(true, cart.AddCart('B', 5, productList, promotionList));
            Assert.AreEqual(true, cart.AddCart('C', 1, productList, promotionList));
            Assert.AreEqual(370, cart.GetCartTotal(productList, promotionList));

            cart = new CartComponent();
            Assert.AreEqual(true, cart.AddCart('A', 3, productList, promotionList));
            Assert.AreEqual(true, cart.AddCart('B', 5, productList, promotionList));
            Assert.AreEqual(true, cart.AddCart('C', 1, productList, promotionList));
            Assert.AreEqual(true, cart.AddCart('D', 1, productList, promotionList));
            Assert.AreEqual(280, cart.GetCartTotal(productList, promotionList));
        }

        //[TestMethod]
        //public void RemoveFromProduct()
        //{
        //    ProductComponent product = new ProductComponent();
        //    Assert.AreEqual(true, product.RemoveProduct('A'));
        //    Assert.AreEqual(true, product.AddProduct('A', 50));
        //}
    }
}