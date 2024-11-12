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
            _stage.CreateMap(MapType.Classic, 200, 200, out Pos startPos);
            _stage.DrawAllMap();

            _mainCamera.transform.position = new Vector3(startPos.x, startPos.y, -10);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
