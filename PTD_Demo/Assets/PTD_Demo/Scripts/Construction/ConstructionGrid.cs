using UnityEngine;
using UnityEngine.Tilemaps;

namespace PTD_Demo
{
    public class ConstructionGrid : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private ConstructionTileProcessor _cTPSO;
        [SerializeField] private GridLayout _gridLayout;
        public GridLayout gridLayout => _gridLayout;

        [SerializeField] private Tilemap _tempConstructionMap;
        [SerializeField] private Tilemap _worldConstructionMap;

        private ConstructableUnit _currentUnit;
        private Vector3 _prevUnitPos;
        private BoundsInt _prevUnitArea;

        public void SpawnBuilding(GameObject _houseBuilding)
        {
            if (!_currentUnit)
            {
                _currentUnit = Instantiate(_houseBuilding, Vector3.zero, Quaternion.identity).GetComponent<ConstructableUnit>();
                _currentUnit.AssignGrid(this);
                FollowConstructionUnit();
            }
        }

        private void Update()
        {
            ConstructionPlacement();
        }

        private void ConstructionPlacement()
        {
            if (!_currentUnit)
                return;

            if (!_currentUnit.placed)
            {
                Vector2 touchPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int tilePos = _gridLayout.LocalToCell(touchPos);

                if (_prevUnitPos != tilePos)
                {
                    _currentUnit.transform.localPosition = _gridLayout.CellToLocalInterpolated(tilePos + new Vector3(.5f, .5f, 0f));
                    _prevUnitPos = tilePos;
                    FollowConstructionUnit();
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (CanPlaceCurrentUnit())
                    ConstructOnArea();
            }

            else if (Input.GetMouseButtonDown(1))
            {
                _cTPSO.ClearTiledArea(_prevUnitArea, _tempConstructionMap);
                Destroy(_currentUnit.gameObject);
            }
        }

        private void FollowConstructionUnit()
        {
            _cTPSO.ClearTiledArea(_prevUnitArea, _tempConstructionMap);

            _currentUnit.SetCAPosition(_gridLayout.WorldToCell(_currentUnit.gameObject.transform.position));
            BoundsInt currentBuildingArea = _currentUnit.constructionArea;

            TileBase[] worldTiles = _cTPSO.GetTilesBlock(currentBuildingArea, _worldConstructionMap);
            TileBase[] tilesToConstruct = new TileBase[worldTiles.Length];

            for (int i = 0; i < worldTiles.Length; i++)
            {
                if (worldTiles[i] == _cTPSO.constructionTiles[TileType.White])
                {
                    tilesToConstruct[i] = _cTPSO.constructionTiles[TileType.Green];
                }
                else
                {
                    _cTPSO.FillTiles(tilesToConstruct, TileType.Red);
                    break;
                }
            }

            _tempConstructionMap.SetTilesBlock(currentBuildingArea, tilesToConstruct);
            _prevUnitArea = currentBuildingArea;
        }

        private bool ConstructionAreaAvailable(BoundsInt area)
        {
            TileBase[] tilesToCheck = _cTPSO.GetTilesBlock(area, _worldConstructionMap);
            foreach (TileBase tile in tilesToCheck)
            {
                if (tile != _cTPSO.constructionTiles[TileType.White])
                {
                    Debug.Log("Cannot place construction here.");
                    return false;
                }
            }

            return true;
        }

        public bool CanPlaceCurrentUnit() => ConstructionAreaAvailable(_currentUnit.constructionArea);

        public void ConstructOnArea()
        {
            _cTPSO.SetTilesBlock(_currentUnit.constructionArea, TileType.Empty, _tempConstructionMap);
            _cTPSO.SetTilesBlock(_currentUnit.constructionArea, TileType.Yellow, _worldConstructionMap);
            _currentUnit.SetUnitPlaced(true);
            _currentUnit = null;
        }
    }
}