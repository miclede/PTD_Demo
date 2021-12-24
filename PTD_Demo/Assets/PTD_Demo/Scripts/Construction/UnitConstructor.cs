using System;
using System.Collections;
using UnityEngine;

namespace PTD_Demo
{
    public class UnitConstructor : MonoBehaviour
    {
        [SerializeField] private ConstructionGrid _constructionGrid;

        private ConstructableUnit _ghostUnit;

        private Vector3 _prevUnitPos;
        public Vector3 prevUnitPos => _prevUnitPos;
        public Action<Vector3> AssignPrevUnitPos => (pos) => _prevUnitPos = pos;

        private BoundsInt _prevUnitArea;
        public Action<BoundsInt> SetPrevUnitArea => (set) => _prevUnitArea = set;

        public delegate void ConstructUnit(ConstructableUnit unit);
        public ConstructUnit constructUnit;
        public Action<ConstructableUnit> Construct => (unit) => constructUnit(unit);

        private void Awake()
        {
            constructUnit += (ghost) => _constructionGrid.SetConstructedTiles(ghost);
            constructUnit += (ghost) => CleanupPlacement(ghost);
        }

        public void SpawnBuilding(ShopMerchandiseSO merch, bool canPurchase)
        {
            if (!_ghostUnit && canPurchase)
            {
                _ghostUnit = Instantiate(merch.merchObject, Vector3.zero, Quaternion.identity).GetComponent<ConstructableUnit>();
                _ghostUnit.AssignGrid(_constructionGrid);
                _constructionGrid.AssignGhostToGrid(_ghostUnit, _prevUnitArea, SetPrevUnitArea);
                StartCoroutine(ConstructionCoroutine(merch));
            }
            else Debug.Log("Cannot afford: " + merch.merchName);
        }

        public IEnumerator ConstructionCoroutine(ShopMerchandiseSO merch)
        {
            while (_ghostUnit)
            {
                ConstructionPlacement(merch);

                yield return null;
            }
        }

        private void ConstructionPlacement(ShopMerchandiseSO merch)
        {
            Camera constCam = _constructionGrid.constructionCamera;
            GridLayout gridLayout = _constructionGrid.gridLayout;

            if (!_ghostUnit)
                return;

            if (!_ghostUnit.placed)
            {
                Vector2 touchPos = constCam.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int tilePos = gridLayout.LocalToCell(touchPos);

                if (_prevUnitPos != tilePos)
                {
                    _ghostUnit.transform.localPosition = gridLayout.CellToLocalInterpolated(tilePos + new Vector3(.5f, .5f, 0f));
                    _prevUnitPos = tilePos;
                    _constructionGrid.AssignGhostToGrid(_ghostUnit, _prevUnitArea, SetPrevUnitArea);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (AreaPlaceable())
                    constructUnit(_ghostUnit);
            }

            else if (Input.GetMouseButtonDown(1))
            {
                _constructionGrid.ClearTiles(_prevUnitArea);
                Destroy(_ghostUnit.gameObject);
            }
        }

        private bool AreaPlaceable() => _constructionGrid.IsAreaAvailable(_ghostUnit.constructionArea);
        
        private void CleanupPlacement(ConstructableUnit unit)
        {
            unit.SetUnitPlaced(true);
            _ghostUnit = null;
        }
    }
}