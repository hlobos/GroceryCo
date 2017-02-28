using GroceryCo.Model;
using System;
using System.Collections.Generic;

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
            //Json the price catalog into items to get most recent prices...
            //allItems list from json...create items

            //LIMITATION: No current interface for user to add promotions 
            //Create an OnSale promotion for apples into allPromotions list
            List<Promotion> allPromotions = new List<Promotion>();

            var basketContents = GetBasketContents();
            if (basketContents != null && basketContents.Length != 0)
            {
                List<Item> purchasedItems = new List<Item>();

                foreach (string basketItem in basketContents)
                {
                    //if basketItem matches an allItem by Name add to purchasedItems 
                }

                Cashier.DoCheckout(purchasedItems, allPromotions);
            }
        }

        private string[] GetBasketContents()
        {
            string[] basketContents;

            try
            {
                basketContents = System.IO.File.ReadAllLines("../../Files/Baskets/basket-02.txt");
            }
            catch
            {
                throw new Exception("Unable to Read in Basket");
            }

            return basketContents;
        }
    }
}
