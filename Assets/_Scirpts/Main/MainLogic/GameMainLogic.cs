using System.Resources;
using UnityEditor.SceneManagement;
using UnityEngine;
using Game.DataResources;
namespace Game.Main
{
    public class GameMainLogic : MonoBehaviour
    {
        [SerializeField] private Stage _stage;
        [SerializeField] private Camera _mainCamera;
        private GameObject _player;

        /// <summary>
        /// Release
        /// </summary>
        private void OnDestroy() {
            _stage.ReleaseResource();
        }
        /// <summary>
        /// 초기화
        /// </summary>
        private void Init() {
            _stage.InitializeMap(200, 200);
            _stage.SetSeed(Random.Range(0, 200));
            _stage.LoadResource(DataResources.ResourceLabelName.Field_Standard);
        }


        private void Awake() {
            Init();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _stage.CreateMap(MapType.Classic, 200, 200, out Pos startPos);
            _stage.DrawAllMap();
            // 카메라 위치 초기화
            _mainCamera.transform.position = new Vector3(startPos.x, startPos.y - 7, -10);
            // 플레이어 초기화
            GameObject playerObj = DataResources.ResourceManager.Instance.SyncLoad(AddressableKey.Player);
            _player = Instantiate(playerObj);
            _player.transform.position = new Vector3(startPos.x, startPos.y, -1);
        }



        #region Test Code
        // 자동 맵 생성 확인
        float time = 10;
        float timer = 0;
        // Update is called once per frame
        void Update()
        {
            DungeonSpawnTest();
        }

        private void DungeonSpawnTest() {
            timer += Time.deltaTime;
            if (timer > time) {
                timer -= time;
                _stage.ClearMap();
                _stage.SetSeed(-1);
                _stage.CreateMap(MapType.Classic, 200, 200, out Pos startPos);
                _stage.DrawAllMap();
                _mainCamera.transform.position = new Vector3(startPos.x, startPos.y - 7, -10);
            }
        }
        #endregion
    }
}
