using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;

namespace PTD_Demo
{
    public enum CurrencyType
    {
        Gold,
        Material
    }

    public abstract class Wallet : SerializedMonoBehaviour
    {
        public Action<Dictionary<CurrencyType, int>> MakePaymentCallback => (cost) => MakePayment(cost);

        [ShowInInspector]
        protected Dictionary<CurrencyType, int> _walletHoldings = new Dictionary<CurrencyType, int>();
        public Dictionary<CurrencyType, int> walletHoldings => _walletHoldings;

        protected virtual void Awake()
        {
            InitializeHoldings();
        }

        public void PaymentCollection(PaymentsSO payment)
        {
            foreach (KeyValuePair<CurrencyType, int> currency in payment.payments)
            {
                _walletHoldings[currency.Key] += currency.Value;
            }
        }

        protected void InitializeHoldings()
        {
            foreach (CurrencyType currency in Enum.GetValues(typeof(CurrencyType)))
            {
                _walletHoldings.Add(currency, 0);
            }
        }

        private void MakePayment(Dictionary<CurrencyType, int> cost)
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