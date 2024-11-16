using System.Collections.Generic;
using UnityEngine;

namespace Game.Main
{
    public interface IAI
    {
        internal void Work(Stage owner);
    }
    public interface ISkill {
        internal void Work(Stat stat);

        internal List<Character> GetTarget();
    }
}
