using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace PTD_Demo
{
    [CreateAssetMenu(fileName = "PaymentSO", menuName = "Payment")]
    public class PaymentsSO : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<CurrencyType, int> _payments = new Dictionary<CurrencyType, int>();
        public Dictionary<CurrencyType, int> payments => _payments;
    }
}