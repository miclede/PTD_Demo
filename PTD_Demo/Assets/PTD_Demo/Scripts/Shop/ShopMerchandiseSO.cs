using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace PTD_Demo
{
    [CreateAssetMenu(fileName = "Merchandise", menuName = "Shop/Merchandise")]
    public class ShopMerchandiseSO : SerializedScriptableObject
    {
        [SerializeField] private string _merchName;
        public string merchName => _merchName;

        [SerializeField] private GameObject _merchObject;
        public GameObject merchObject => _merchObject;

        [SerializeField] private int _merchID;
        public int merchID => _merchID;

        [SerializeField] private Dictionary<CurrencyType, int> _merchCost = new Dictionary<CurrencyType, int>();
        public Dictionary<CurrencyType, int> merchCost => _merchCost;
    }
}