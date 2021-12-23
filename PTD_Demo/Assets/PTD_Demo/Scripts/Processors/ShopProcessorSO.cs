using UnityEngine;
using System.Collections.Generic;

namespace PTD_Demo
{
    [CreateAssetMenu(fileName = "ShopPSO", menuName = "Processor/Shop")]
    public class ShopProcessorSO : ScriptableObject
    {
        public void ProcessPayment(Wallet wallet, ShopMerchandiseSO merchandise)
        {
            if (CanAffordPayment(wallet, merchandise))
            {
                wallet.MakePayment(merchandise.merchCost);
            }
        }

        public bool CanAffordPayment(Wallet wallet, ShopMerchandiseSO merchandise)
        {
            bool canPurchase = false;

            foreach (KeyValuePair<CurrencyType, int> item in wallet.walletHoldings)
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