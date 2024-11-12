using System;
using UnityEngine;

namespace Game.Main
{
    public struct Pos
    {
        public int x;
        public int y;
    }

    [Serializable]
    internal class MapResoure {
        public GameObject roadPrefab;
        public GameObject startPrefab;
        public GameObject endPrefab;
    }
}
