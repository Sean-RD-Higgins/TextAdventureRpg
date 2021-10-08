using System;
using System.Collections;
using System.Collections.Generic;

namespace TextAdventureRpgLibrary
{
    public class ShopMapTile : IMapTile
    {
        public ShopMapTile()
        {
            ArrivalText = new string[] { };
            LookText = new string[] { };
            Actions = GetActions();
        }

        public ShopMapTile(string[] arrivalText, string[] lookText, TimeSpan shopTimeOpen, TimeSpan shopTimeClose)
        {
            shopTimeOpen = new TimeSpan(7, 30, 0);
            shopTimeClose = new TimeSpan(12+6, 00, 0);
            DateTime currentDateTime = DateTime.Now;
            currentDateTime.Add(shopTimeOpen);
            ArrivalText = arrivalText;
            LookText = lookText;
            Actions = GetActions();
        }

        public IEnumerable<string> ArrivalText { get; set; }
        public IEnumerable<string> LookText { get; set; }
        public ActionCollection Actions { get; set; }

        private ActionCollection GetActions()
        {
            ActionCollection actionCollection = new ActionCollection();
            actionCollection.Add("Buy", Buy);
            return actionCollection;
        }

        public IEnumerable<string> Buy(string additionalInput, World currentWorld)
        {
            // TODO - Do logic if the shop is closed or not.
            int costPerItem = 20;
            if (int.TryParse(additionalInput, out int purchaseCount))
            {
                int totalCost = purchaseCount * costPerItem;
                if (currentWorld.PlayerOne.Currency > totalCost)
                {
                    currentWorld.PlayerOne.Currency -= totalCost;
                    currentWorld.PlayerOne.PotionCount += purchaseCount;
                    return new string[] { $"For a total of {totalCost} Currency, you have purchased {purchaseCount} potions!  Thank you for your purchase!" };
                }
                return new string[] { "You seem to lack the money." };
            }

            return new string[] { "How many do you wish to buy?  Just say \"buy 1\" or \"buy 5\" to purchase." };
        }

    }
}