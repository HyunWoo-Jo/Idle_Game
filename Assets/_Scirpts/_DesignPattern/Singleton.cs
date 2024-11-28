using NUnit.Framework;
using UnityEngine;

namespace Game.DesignPattern
{
    [DefaultExecutionOrder(-100)]
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get { return _instance; } }
        private static T _instance;
        /// <summary>
        /// Init
        /// </summary>
        protected virtual void Awake() {
            if(_instance) {
                Destroy(this.gameObject);
            } else {
                _instance = this.GetComponent<T>();
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}
