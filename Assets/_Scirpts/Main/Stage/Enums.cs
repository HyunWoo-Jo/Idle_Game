using UnityEngine;

namespace Game.Main
{
    public enum MapType {
        Classic,
        Boss
    }

    public enum BlockType {
        None,
        Wall,
        Road,
        Room,
        BigRoom,
        Treasure,
        Start,
        End,
    }

    public enum Direction {
        East,
        West,
        South,
        North
    }
}
