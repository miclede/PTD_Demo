using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Sirenix.OdinInspector;

namespace PTD_Demo
{
    public enum TileType { Empty, White, Green, Red, Yellow }

    [CreateAssetMenu(fileName = "CTPSO", menuName = "Processor/TilePSO")]
    public class ConstructionTileProcessorSO : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<TileType, TileBase> _constructionTiles = new Dictionary<TileType, TileBase>();
        public Dictionary<TileType, TileBase> constructionTiles => _constructionTiles;

        public void ClearTiledArea(BoundsInt area, Tilemap tilemap)
        {
            TileBase[] tilesToClear = new TileBase[area.size.x * area.size.y * area.size.z];
            FillTiles(tilesToClear, TileType.Empty);
            tilemap.SetTilesBlock(area, tilesToClear);
        }

        public TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
        {
            int count = 0;
            TileBase[] tiles = new TileBase[area.size.x * area.size.y * area.size.z];

            foreach (Vector3Int vectorInt in area.allPositionsWithin)
            {
                Vector3Int tilePos = new Vector3Int(vectorInt.x, vectorInt.y, 0);

                tiles[count] = tilemap.GetTile(tilePos);
                count++;
            }

            return tiles;
        }

        public void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
        {
            int areaSize = area.size.x * area.size.y * area.size.z;
            TileBase[] tiles = new TileBase[areaSize];
            FillTiles(tiles, type);
            tilemap.SetTilesBlock(area, tiles);
        }

        public void FillTiles(TileBase[] tiles, TileType type)
        {
            for (int i = 0; i < tiles.Length; i++)
                tiles[i] = _constructionTiles[type];
        }
    }
}