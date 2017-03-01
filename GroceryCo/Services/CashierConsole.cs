using GroceryCo.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace GroceryCo.Services
{
    public class CashierConsole
    {

        public void run()
        {
            StartCheckout();
        }

        private void StartCheckout()
        {
            List<Item> purchasedItems = new List<Item>();
            List<Promotion> allPromotions = new List<Promotion>();
            
            string[] basketContents = GetBasketContents();
            JArray priceCatalog = GetPriceCatalog();
            JArray promotions = GetPromotions();

            var itemName = "";
            decimal itemPrice = 0;

            if (basketContents != null && basketContents.Length != 0 && priceCatalog != null && priceCatalog.Count != 0)
            {
                foreach (string basketItem in basketContents)
                {
                    //Check basketItem against the content in priceCatalog
                    foreach (JObject content in priceCatalog.Children<JObject>())
                    {
                        itemName = (string)content.GetValue("Name");
                 
                        if (itemName.ToUpper() == basketItem.ToUpper())
                        {
                            itemPrice = (decimal)content.GetValue("Price");

                            //Load purchasedItems list
                            purchasedItems.Add(new Item(itemName, itemPrice));
                        }
                    }
                }

                //Load allPromotions list
                foreach (JObject content in promotions.Children<JObject>())
                {
                    PromotionType promotionType = null;

                    switch ((string)content.GetValue("Type"))
                    {
                        case "OnSale":
                            promotionType = PromotionType.OnSale;
                            break;
                        case "GroupSale":
                            promotionType = PromotionType.GroupSale;
                            break;
                        case "BOGOFree":
                            promotionType = PromotionType.BOGOFree;
                            break;
                        case "BOGOPercent":
                            promotionType = PromotionType.BOGOPercent;
                            break;
                    }

                    allPromotions.Add(new Promotion(
                        (string)content.GetValue("Name"), (string)content.GetValue("ItemName"), promotionType, 
                        (DateTime)content.GetValue("BeginDate"), (int)content.GetValue("DaysValid"), 
                        (decimal)content.GetValue("Discount"), (int)content.GetValue("RequiredItems")));
                }

                Cashier.DoCheckout(purchasedItems, allPromotions);
            }
            else
            {
                Console.WriteLine("Sorry, there has been an error with your purchase!");
            }  
        }

        private JArray GetPromotions()
        {
            JArray promotions;

            try
            {
                promotions = JArray.Parse(File.ReadAllText("../../Files/Promotions.json"));
            }
            catch
            {
                throw new Exception("Unable to Read in Promotions");
            }

            return promotions;
        }

        private JArray GetPriceCatalog()
        {
            JArray priceCatalog;

            try
            {
                priceCatalog = JArray.Parse(File.ReadAllText("../../Files/PriceCatalog.json"));
            }
            catch
            {
                throw new Exception("Unable to Read in Price Catalog");
            }
            
            return priceCatalog;
        }

        private string[] GetBasketContents()
        {
            string[] basketContents;

            try
            {
                basketContents = File.ReadAllLines("../../Files/Baskets/basket-01.txt");
            }
            catch
            {
                throw new Exception("Unable to Read in Basket");
            }

            return basketContents;
        }
    }
}
