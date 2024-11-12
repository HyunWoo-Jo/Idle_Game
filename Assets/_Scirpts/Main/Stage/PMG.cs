using UnityEngine;
using System;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using UnityEngine.WSA;
namespace Game.Main
{
    /// <summary>
    /// Procedural Map Generation
    /// 절차적 맵 생성
    /// </summary>
    public class ProceduralMapGeneration 
    {
        private int _seed;
        private int _xSize;
        private int _ySize;

        internal void SetSeed(int seed = -1) {
            _seed = seed;
        }
        /// <summary>
        /// Classic Map을 생성하는 함수
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        internal void CreateClassicMap(BlockType[,] map, int x, int y, out Pos startPos) {
            _xSize = Math.Min(x, map.GetLength(0)) - 1;
            _ySize = Math.Min(y, map.GetLength(1)) - 1;
            int totalSize = (_xSize * _ySize) - 2;
            
            // 시드 설정
            if(_seed == -1) {
                _seed = DateTime.Now.Second;
            }
            UnityEngine.Random.InitState(_seed);

            // 방향 세팅
            Direction mainDriection = (Direction)UnityEngine.Random.Range(0, 4);
            Direction curDirection = mainDriection;
            // 시작 지점 가지고 오기
            startPos = GetStartPosition(mainDriection);
            map[startPos.x, startPos.y] = BlockType.Start;
            Pos curPos = startPos;
            Pos nextPos = NextPos(curPos, curDirection);
            do {
                curPos = nextPos;
                map[curPos.x, curPos.y] = BlockType.Road;

                //벽 생성
                Pos wallPos = curPos;
                wallPos.y += 1;
                if(IsAble(map, wallPos) && map[wallPos.x, wallPos.y].Equals(BlockType.None)) {
                    map[wallPos.x, wallPos.y] = BlockType.Wall;
                }

                curDirection = NextDirection(mainDriection, curDirection);
                nextPos = NextPos(nextPos, curDirection);
                
            } while (IsAble(map, nextPos));

            map[curPos.x, curPos.y] = BlockType.End;

            // clear seed
            UnityEngine.Random.InitState(DateTime.Now.Second);
        }

        /// <summary>
        /// 방향에 따른 시작지점을 가지고 오는 함수
        /// </summary>
        /// <param name="mainDirection"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        private Pos GetStartPosition(Direction mainDirection) {
            Pos pos;
            if (mainDirection.Equals(Direction.East)) {
                pos.x = 0;
                pos.y = UnityEngine.Random.Range(0, _ySize);
            } else if (mainDirection.Equals(Direction.West)) {
                pos.x = _xSize;
                pos.y = UnityEngine.Random.Range(0, _ySize);
            } else if (mainDirection.Equals(Direction.South)) {
                pos.x = UnityEngine.Random.Range(0, _xSize);
                pos.y = _ySize;
            } else { // north
                pos.x = UnityEngine.Random.Range(0, _xSize);
                pos.y = 0;
            }
            return pos;
        }

        /// <summary>
        /// 다음 방향을 구하는 함수
        /// </summary>
        /// <param name="mainDirection"></param>
        private Direction NextDirection(Direction mainDirection, Direction curDirection) {
            Direction nextDirection;
            int nextRand = UnityEngine.Random.Range(0, 2);

            if (mainDirection == Direction.East || mainDirection == Direction.West) {
                nextDirection = (nextRand == 0 && curDirection != Direction.South) ? Direction.North :
                                (nextRand == 1 && curDirection != Direction.North) ? Direction.South :
                                mainDirection;
            } else { // South or North
                nextDirection = (nextRand == 0 && curDirection != Direction.West) ? Direction.East :
                                (nextRand == 1 && curDirection != Direction.East) ? Direction.West :
                                mainDirection;
            }
            return nextDirection;
        }
        /// <summary>
        /// 맵이 이용 가능한지 확인하는 함수
        /// </summary>
        /// <param name="map"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private bool IsAble(BlockType[,] map, Pos pos) {
            if (pos.x > _xSize || pos.y > _ySize || pos.x < 0 || pos.y < 0) return false;
            else return true;
        }

        /// <summary>
        /// 다음 위치를 구하는 함수
        /// </summary>
        /// <param name="curPos"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private Pos NextPos(Pos curPos, Direction direction) {
            if (direction.Equals(Direction.North)) {
                curPos.y += 1;
            } else if (direction.Equals(Direction.South)) {
                curPos.y -= 1;
            } else if (direction.Equals(Direction.West)){
                curPos.x -= 1;
            } else if (direction.Equals(Direction.East)) {
                curPos.x += 1;
            }
            return curPos;
        }
        
    }
}
