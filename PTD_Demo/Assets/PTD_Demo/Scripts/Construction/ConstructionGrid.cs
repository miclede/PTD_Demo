using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PTD_Demo
{
    public class ConstructionGrid : MonoBehaviour
    {
        [SerializeField] private Camera _constructionCamera;
        public Camera constructionCamera => _constructionCamera;

        [SerializeField] private ConstructionTileProcessorSO _cTPSO;
        [SerializeField] private GridLayout _gridLayout;
        public GridLayout gridLayout => _gridLayout;

        [SerializeField] private Tilemap _ghostConstructionMap;
        [SerializeField] private Tilemap _worldConstructionMap;

        public Action<ConstructableUnit, BoundsInt, Action<BoundsInt>> AssignGhostToGrid => (ghost, prevArea, setPrevArea) => FollowConstructableUnit(ghost, prevArea, setPrevArea);
        public Action<BoundsInt> ClearTiles => (area) => _cTPSO.ClearTiledArea(area, _ghostConstructionMap);
        public Func<BoundsInt, bool> IsAreaAvailable => (area) => ConstructionAreaAvailable(area);

        private void FollowConstructableUnit(ConstructableUnit unit, BoundsInt prevArea, Action<BoundsInt> setPrevArea)
        {
            _cTPSO.ClearTiledArea(prevArea, _ghostConstructionMap);

            unit.SetCAPosition(_gridLayout.WorldToCell(unit.gameObject.transform.position));
            BoundsInt currentBuildingArea = unit.constructionArea;

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

            _ghostConstructionMap.SetTilesBlock(currentBuildingArea, tilesToConstruct);
            setPrevArea(currentBuildingArea);
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

        public void SetConstructedTiles(ConstructableUnit unit)
        {
            _cTPSO.SetTilesBlock(unit.constructionArea, TileType.Empty, _ghostConstructionMap);
            _cTPSO.SetTilesBlock(unit.constructionArea, TileType.Yellow, _worldConstructionMap);
        }
    }
}