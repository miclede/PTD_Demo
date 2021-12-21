using UnityEngine;

namespace PTD_Demo
{
    public enum StockType
    {
        Fortification,
        Tower,
        Spawner
    }

    public struct Merchandise
    {
        public string stockName;
        public GameObject stockObject;
    }
}