using UnityEngine;

namespace PTD_Demo
{
    public class PlayerDirector : MonoBehaviour
    {
        [SerializeField] private Storefront _myStorefront;
        [SerializeField] private PlayerWallet _myWallet;
        [SerializeField] private UnitConstructor _myUnitConstructor;

        private void PurchaseConstructable(ShopMerchandiseSO merchandise) => 
            _myStorefront.PurchaseMerch(_myWallet.walletHoldings, merchandise, _myWallet.MakePaymentCallback);

        private void Awake()
        {
            _myUnitConstructor.constructUnit += 
                (unit) => PurchaseConstructable(unit.merchandiseSO);

            _myStorefront.spawnGoods +=
                (merch) => _myUnitConstructor.SpawnBuilding(merch, _myStorefront.PriceCheck(_myWallet.walletHoldings, merch));
        }
    }
}