using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

namespace PTD_Demo
{
    public abstract class Wallet : SerializedMonoBehaviour
    {
        [ShowInInspector]
        protected Dictionary<CurrencyType, int> _walletHoldings = new Dictionary<CurrencyType, int>();
        public Dictionary<CurrencyType, int> walletHoldings => _walletHoldings;

        protected virtual void Awake()
        {
            InitializeHoldings();
        }

        protected void InitializeHoldings()
        {
            foreach (CurrencyType currency in Enum.GetValues(typeof(CurrencyType)))
            {
                _walletHoldings.Add(currency, 0);
            }
        }

        public void MakePayment(Dictionary<CurrencyType, int> cost)
        {
            foreach (KeyValuePair<CurrencyType, int> currency in cost)
            {
                if (_walletHoldings[currency.Key] - cost[currency.Key] >= 0)
                    _walletHoldings[currency.Key] -= cost[currency.Key];
                else break;
            }
        }
    }
}