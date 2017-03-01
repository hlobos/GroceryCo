using GroceryCo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryCo.Services
{
    internal class Cashier
    {
        internal static void DoCheckout(List<Item> purchasedItems, List<Promotion> allPromotions)
        {
            decimal purchaseTotal = 0;
            StringBuilder itemsStub = new StringBuilder();

            foreach (var item in purchasedItems)
            {
                purchaseTotal = purchaseTotal + item.Price;
                itemsStub.AppendFormat("{0,-35}{1:C}{2}", "\t" + item.Name, item.Price, "\n");

                //Check for a promotion and apply it if it is current
                foreach (var promotion in allPromotions)
                {
                    string promoItemName = promotion.ItemName;
                    string purchasedItemName = item.Name;

                    if (promoItemName.ToUpper() == purchasedItemName.ToUpper()
                            && promotion.BeginDate <= DateTime.Today
                            && promotion.CalculateExpirationDate() > DateTime.Today)
                    {
                        decimal discountForPurchase = ApplyPromotion(item, promotion);
                        purchaseTotal = purchaseTotal - discountForPurchase;

                        itemsStub.AppendFormat("{0,-15}{1:C}{2}", "\t\tPROMO " + promotion.Type + "\t-", discountForPurchase, "\n");
                    }
                }
            }

            string totalStub = Receipt.GenerateTotalStub(purchaseTotal);

            Console.WriteLine(itemsStub);
            Console.WriteLine(totalStub);
        }

        private static decimal ApplyPromotion(Item item, Promotion promotion)
        {
            decimal discount = 0;

            switch (promotion.Type.ToString())
            {
                case "OnSale":
                    discount = item.Price - promotion.Discount;
                    break;
                case "GroupSale":
                    //discount = (item.Price * promotion.RequiredItems) - promotion.Discount;
                    break;
                case "BOGOFree":
                    //discount = item.Price;
                    break;
                case "BOGOPercent":
                    //discount = (promotion.Discount / 100) * item.Price;
                    break;
            }

            return discount;
        }
    }
}