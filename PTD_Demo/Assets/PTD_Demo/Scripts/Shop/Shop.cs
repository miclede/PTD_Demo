using UnityEngine;
using System.Collections.Generic;
using System;

namespace PTD_Demo
{
    public abstract class Shop : MonoBehaviour
    {
        public Func<Dictionary<CurrencyType, int>, ShopMerchandiseSO, bool> PriceCheck => 
            (holdings, merch) => CanAffordPayment(holdings, merch);
        public Action<Dictionary<CurrencyType, int>, ShopMerchandiseSO, Action<Dictionary<CurrencyType, int>>> PurchaseMerch =>
            (holdings, merch, callback) => MakePurchase(holdings, merch, callback);

        protected void MakePurchase(Dictionary<CurrencyType, int> holdings, ShopMerchandiseSO merch, Action<Dictionary<CurrencyType, int>> callback)
        {
            if (PriceCheck(holdings, merch)) callback(merch.merchCost);
        }

        protected bool CanAffordPayment(Dictionary<CurrencyType, int> holdings, ShopMerchandiseSO merchandise)
        {
            bool canPurchase = false;

            foreach (KeyValuePair<CurrencyType, int> item in holdings)
            {
                if (item.Value >= merchandise.merchCost[item.Key])
                {
                    canPurchase = true;
                }
                else if (item.Value < merchandise.merchCost[item.Key])
                {
                    canPurchase = false;
                    break;
                }
            }

            return canPurchase;
        }
    }
}