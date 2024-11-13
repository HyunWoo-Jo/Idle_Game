using UnityEngine;
using System.Collections.Generic;

namespace Game.Main
{
    public interface ISkill
    {
        internal void Work(Stat stat);

        internal List<Character> GetTarget();
    }
}
