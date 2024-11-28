using Codice.Client.BaseCommands;
using UnityEngine;
using Game.DataResources;
using System.Collections;
using System.Collections.Generic;
namespace Game.Main
{
   

    public class Stage : MonoBehaviour
    {
        private readonly ProceduralMapGeneration _pmg = new();
        private BlockType[,] _map;
        private int _x, _y;
        private ResourceLabelName _curLabel;
        [SerializeField]
        private MapResoure _mapResource;

        /// <summary>
        /// map resource load
        /// </summary>
        /// <param name="label"></param>
        public void LoadResource(ResourceLabelName label) {
            IList<GameObject> loadList = ResourceManager.Instance.SyncLoadLabel(label);
            _curLabel = label;

            foreach (GameObject go in loadList) {
                if (go.name.Contains("Wall")) {
                    _mapResource.wallPrefab = go;
                } else if (go.name.Contains("Road")) {
                    _mapResource.roadPrefab = go;
                } else if (go.name.Contains("Start")) {
                    _mapResource.startPrefab = go;
                } else if (go.name.Contains("End")) {
                    _mapResource.endPrefab = go;
                }
            }
        }
        /// <summary>
        /// map resource Unload
        /// </summary>
        public void ReleaseResource() {
            ResourceManager.Instance.ReleaseLabel(_curLabel);
        }


        /// <summary>
        /// �� �ʱ�ȭ
        /// </summary>
        /// <param name="x"> x size </param>
        /// <param name="y"> y size </param>
        public void InitializeMap(int x, int y) {
            _map = new BlockType[x, y];
            _x = x;
            _y = y;
        }
        /// <summary>
        /// �õ� ����
        /// </summary>
        /// <param name="seed"></param>
        public void SetSeed(int seed) {
            _pmg.SetSeed(seed);
        }

        /// <summary>
        /// ���� ����
        /// </summary>
        /// <param name="mapType"> �� ���� </param>
        /// <param name="x"> �ִ� x ũ�� </param>
        /// <param name="y"> �ִ� y ũ��</param>
        /// <param name="startPos"> ���� ��ġ </param>
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
        /// Map Data �ʱ�ȭ
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
        /// �� �����͸� ������� �ʿ�����Ʈ�� ����
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
