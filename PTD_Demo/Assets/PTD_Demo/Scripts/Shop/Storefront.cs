using System;
using System.Collections.Generic;
using UnityEngine;

namespace PTD_Demo
{
    public class Storefront : Shop
    {
        [SerializeField] private ShopCatalogSO _shopCatalog;
        [SerializeField] private List<StorefrontButton> _storeFrontButtons;

        public delegate void SpawnGoods(ShopMerchandiseSO goods);
        public SpawnGoods spawnGoods;
        public Action<ShopMerchandiseSO> SpawnGoodsCallback => (goods) => spawnGoods(goods);

        private void Start() => InitializeStorefront();

        private void InitializeStorefront()
        {
            if (_storeFrontButtons.Count == _shopCatalog.availableStock.Count)
            {
                int i = 0;
                foreach (var item in _shopCatalog.availableStock)
                {
                    _storeFrontButtons[i].InitializeButton(SpawnGoodsCallback, item);
                }
            }
            else throw new Exception("There are not enough buttons made for the amount of stock in catalog: " + _shopCatalog);
        }
    }
}