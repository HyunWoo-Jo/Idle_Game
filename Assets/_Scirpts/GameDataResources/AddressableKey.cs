using UnityEngine;

namespace Game.DataResources
{
    public static class AddressableKey
    {
        public static string Player = "Assets/Prefabs/Player.prefab";
        public static string Wall = "Assets/Prefabs/Wall.prefab";
        public static string Start = "Assets/Prefabs/Start.prefab";
        public static string Road = "Assets/Prefabs/Road.prefab";
        public static string End = "Assets/Prefabs/End.prefab";
    }

    public enum ResourceLabelName {
        Field_Standard,
    }
}
