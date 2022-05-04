using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace PTD_Demo
{
    [CreateAssetMenu(fileName = "ShopCatalogSO", menuName = "Shop/Catalog")]
    public class ShopCatalogSO : SerializedScriptableObject
    {
        [SerializeField] private List<ShopMerchandiseSO> _availableStock = new List<ShopMerchandiseSO>();
        public List< ShopMerchandiseSO> availableStock => _availableStock;
    }
}