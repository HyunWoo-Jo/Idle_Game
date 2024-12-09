using UnityEngine;

namespace Game.Main
{
    public abstract class Weapon : MonoBehaviour
    {
        private Stat _stat;
        private ISkill _skill;
        private IAI _ai;


        internal void WorkAI(Stage stage) {
            _ai.Work(stage);
        }

        internal void UseSkill() {
            _skill.Work(_stat);
        }
    }
}
