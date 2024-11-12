using UnityEditor.SceneManagement;
using UnityEngine;

namespace Game.Main
{
    public class GameMainLogic : MonoBehaviour
    {
        [SerializeField] private Stage _stage;
        [SerializeField] private Camera _mainCamera;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _stage.InitializeMap(200, 200);
            _stage.SetSeed(Random.Range(0, 200));
            _stage.CreateMap(MapType.Classic, 200, 200, out Pos startPos);
            _stage.DrawAllMap();

            _mainCamera.transform.position = new Vector3(startPos.x, startPos.y - 7, -10);
        }

        float time = 10;
        float timer = 0;
        // Update is called once per frame
        void Update()
        {
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
    }
}
