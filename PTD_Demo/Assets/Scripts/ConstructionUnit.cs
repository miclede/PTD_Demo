using UnityEngine;

namespace PTD_Demo
{
    public class ConstructionUnit : MonoBehaviour
    {
        private ConstructionGrid _targetGrid;
        public void AssignGrid(ConstructionGrid grid) => _targetGrid = grid;

        [SerializeField] private BoundsInt _constructionArea;
        public BoundsInt constructionArea => _constructionArea;
        public void SetCAPosition(Vector3Int pos) => _constructionArea.position = pos;

        private bool _placed;
        public bool placed => _placed;
        public void SetUnitPlaced(bool placed) => _placed = placed;
    }
}