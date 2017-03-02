using GroceryCo.Model;
using GroceryCo.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GroceryCo.UnitTests.Services
{
    [TestFixture]
    class CashierTest
    {        
        public static IEnumerable<object[]> SingleItemAndPromotionValidNotExpired()
        {
            yield return new object[]
                {
                    new Item("Apple", 5.00m), new Promotion("Apple Quick Sale: All Apples at 50 Cents", "Apple", PromotionType.OnSale,
                        DateTime.Today, 14, 0.50m, 1)
                };
        }

        public static IEnumerable<object[]> SingleItemAndPromotionNotValidExpired()
        {
            yield return new object[]
                {
                    new Item("Apple", 5.00m), new Promotion("Apple Quick Sale: All Apples at 50 Cents", "Apple", PromotionType.OnSale,
                        DateTime.Today.AddDays(-10), 1, 0.50m, 1)
                };
        }

        public static IEnumerable<object[]> SingleItemAndPromotionNotValidFutureDated()
        {
            yield return new object[]
                {
                    new Item("Apple", 5.00m), new Promotion("Apple Quick Sale: All Apples at 50 Cents", "Apple", PromotionType.OnSale,
                        DateTime.Today.AddDays(+1), 14, 0.50m, 1)
                };
        }

        public static IEnumerable<object[]> SingleItemDoesNotMatchPromotionAndPromotionValidNotExpired()
        {
            yield return new object[]
                {
                    new Item("Orange", 5.00m), new Promotion("Apple Quick Sale: All Apples at 50 Cents", "Apple", PromotionType.OnSale,
                        DateTime.Today, 14, 0.50m, 1)
                };
        }

        [Test, TestCaseSource("SingleItemAndPromotionValidNotExpired")]
        public void apply_promotion_OnSale_return_discount_amount_not_expired(Item item, Promotion promotion)
        {
            decimal discount = Cashier.ApplyPromotion(item, promotion);
            decimal expected = 4.50m;

            Assert.AreEqual(expected, discount); 
        }

        [Test, TestCaseSource("SingleItemAndPromotionNotValidExpired")]
        public void apply_promotion_OnSale_return_discount_amount_zero_expired(Item item, Promotion promotion)
        {
            decimal discount = Cashier.ApplyPromotion(item, promotion);
            decimal expected = 0;

            Assert.AreEqual(expected, discount);
        }

        [Test, TestCaseSource("SingleItemAndPromotionNotValidFutureDated")]
        public void apply_promotion_OnSale_return_discount_amount_zero_future_dated(Item item, Promotion promotion)
        {
            decimal discount = Cashier.ApplyPromotion(item, promotion);
            decimal expected = 0;

            Assert.AreEqual(expected, discount);
        }

        [Test, TestCaseSource("SingleItemDoesNotMatchPromotionAndPromotionValidNotExpired")]
        public void apply_promotion_OnSale_return_zero_item_in_promotion_does_not_match_item_name(Item item, Promotion promotion)
        {
            decimal discount = Cashier.ApplyPromotion(item, promotion);
            decimal expected = 0;

            Assert.AreEqual(expected, discount);
        }
    }
}
