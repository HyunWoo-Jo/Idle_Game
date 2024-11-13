using UnityEngine;

namespace Game.Main
{
    public abstract class Weapon : MonoBehaviour
    {
        private Stat _stat;
        private ISkill _skill;
        private IAI _ai;
    }
}
