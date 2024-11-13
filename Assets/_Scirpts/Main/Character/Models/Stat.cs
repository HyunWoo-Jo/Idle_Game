using UnityEngine;

namespace Game.Main
{
    public class Stat {
        private int _maxHp;
        private int _curHp;
        private int _str;
        private int _def;
        private int _level;
        private int _exp;
        private float _moveSpeed;

        internal int MaxHp {
            get { return _maxHp; }
            set { _maxHp = value; }

        }
        internal int CurHp {
            get { return _curHp; }
            set { _curHp = value; }
        }
        internal int Str {
            get { return _str; }
            set { _str = value; }
        }
        internal int Def {
            get { return _def; }
            set { _def = value; }
        }
        internal int Level {
            get { return _level; }
            set { _level = value; }
        }
        internal int Exp {
            get { return _exp; }
            set { _exp = value; }
        }
        internal float MoveSpeed {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }
    }
}
