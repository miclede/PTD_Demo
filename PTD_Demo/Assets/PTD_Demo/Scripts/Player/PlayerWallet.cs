using System;
using System.Collections.Generic;
using UnityEngine;

namespace PTD_Demo
{
    public class PlayerWallet : Wallet
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public void PaymentCollection(PaymentsSO payment)
        {
            foreach (KeyValuePair<CurrencyType, int> collection in payment.payments)
            {
                _walletHoldings[collection.Key] += collection.Value;
            }
        }
    }
}