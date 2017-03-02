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

                        if (discountForPurchase != 0)
                        {
                            purchaseTotal = purchaseTotal - discountForPurchase;

                            string promotionType = promotion.Type.ToString();
                            if (promotionType.Length > 9)
                            {
                                promotionType = promotionType.Substring(0, 9);
                            }

                            itemsStub.AppendFormat("{0,-10}{1:C}{2}", "\t\tPROMO " + promotionType + "\t-", discountForPurchase, "\n");
                        }
                    }
                }
            }

            Receipt.PrintReceipt(itemsStub.ToString(), purchaseTotal);
        }

        public static decimal ApplyPromotion(Item item, Promotion promotion)
        {
            decimal discount = 0;

            if (item != null && promotion != null && item.Name.ToString().ToUpper() == promotion.ItemName.ToUpper() &&
                   promotion.BeginDate <= DateTime.Today && promotion.CalculateExpirationDate() > DateTime.Today)
            {
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
            }

            return discount;
        }
    }
}