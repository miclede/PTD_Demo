using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace PTD_Demo
{
    [CreateAssetMenu(fileName = "ShopCatalogSO", menuName = "Shop/Catalog")]
    public class ShopCatalogSO : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<StockType, ShopMerchandiseSO> _availableStock = new Dictionary<StockType, ShopMerchandiseSO>();
        public Dictionary<StockType, ShopMerchandiseSO> availableStock => _availableStock;
    }
}