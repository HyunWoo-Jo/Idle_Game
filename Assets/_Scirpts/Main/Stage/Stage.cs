using Codice.Client.BaseCommands;
using UnityEngine;

namespace Game.Main
{
   

    public class Stage : MonoBehaviour
    {
        private readonly ProceduralMapGeneration _pmg = new();
        private BlockType[,] _map;
        private int _x, _y;

        [SerializeField]
        private MapResoure _mapResource;


        /// <summary>
        /// 맵 초기화
        /// </summary>
        /// <param name="x"> x size </param>
        /// <param name="y"> y size </param>
        public void InitializeMap(int x, int y) {
            _map = new BlockType[x, y];
            _x = x;
            _y = y;
        }
        /// <summary>
        /// 시드 변경
        /// </summary>
        /// <param name="seed"></param>
        public void SetSeed(int seed) {
            _pmg.SetSeed(seed);
        }

        /// <summary>
        /// 던전 생성
        /// </summary>
        /// <param name="mapType"> 맵 종류 </param>
        /// <param name="x"> 최대 x 크기 </param>
        /// <param name="y"> 최대 y 크기</param>
        /// <param name="startPos"> 시작 위치 </param>
        public void CreateMap(MapType mapType, int x, int y, out Pos startPos) {
            switch (mapType) {
                case MapType.Classic:
                _pmg.CreateClassicMap(_map, x, y, out startPos);
                return;
                case MapType.Boss:
                break;
            }
            startPos = new Pos();
        }

        /// <summary>
        /// Map Data 초기화
        /// </summary>
        public void ClearMap() {
            for (int i = 0; i < _x; i++) {
                for (int j = 0; j < _y; j++) {
                    _map[i, j] = BlockType.None;
                }
            }
            foreach(Transform chTr in this.transform) {
                Destroy(chTr.gameObject);
            }
        }

        /// <summary>
        /// 맵 데이터를 기반으로 맵오브젝트를 생성
        /// </summary>
        
        public void DrawAllMap() {
            for (int i = 0; i < _x; i++) {
                for (int j = 0; j < _y; j++) {
                    if (_map[i, j].Equals(BlockType.Road)) {
                        GameObject obj = Instantiate(_mapResource.roadPrefab, this.transform);
                        obj.transform.position = new Vector2(i, j);
                    } else if (_map[i, j].Equals(BlockType.Start)) {
                        GameObject obj = Instantiate(_mapResource.startPrefab, this.transform);
                        obj.transform.position = new Vector2(i, j);
                    } else if (_map[i, j].Equals(BlockType.End)) {
                        GameObject obj = Instantiate(_mapResource.endPrefab, this.transform);
                        obj.transform.position = new Vector2(i, j);
                    } else if (_map[i, j].Equals(BlockType.Wall)) {
                        GameObject obj = Instantiate(_mapResource.wallPrefab, this.transform);
                        obj.transform.position = new Vector2(i, j);
                    }
                }
            }
        }
    }
}
