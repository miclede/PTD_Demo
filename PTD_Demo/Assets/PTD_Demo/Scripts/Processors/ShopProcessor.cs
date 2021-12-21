using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace PTD_Demo
{
    [CreateAssetMenu(fileName = "ShopPSO", menuName = "Processor/Shop")]
    public class ShopProcessor : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<StockType, Merchandise> _availableUnits = new Dictionary<StockType, Merchandise>();
        public Dictionary<StockType, Merchandise> availableUnits => _availableUnits;
    }
}