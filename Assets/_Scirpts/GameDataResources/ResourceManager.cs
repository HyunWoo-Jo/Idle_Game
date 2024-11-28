using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEngine.AddressableAssets;
using System;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Game.DesignPattern;
namespace Game.DataResources
{
    public enum ResourceLabelName {
        Field_Standard,
    }

    public class ResourceManager : Singleton<ResourceManager>
    {
        private readonly Dictionary<ResourceLabelName, AsyncOperationHandle<IList<GameObject>>> _loaded_label_dictionary = new();

        /// <summary>
        /// 동기 Label 로드
        /// </summary>
        /// <param name="label"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IList<GameObject> SyncLoadLabel(ResourceLabelName label, Action<GameObject> callback = null) {
            if (_loaded_label_dictionary.ContainsKey(label)) {
                return _loaded_label_dictionary[label].Result;
            } else {
                AsyncOperationHandle<IList<GameObject>> handle = Addressables.LoadAssetsAsync<GameObject>(label.ToString(), callback);
                _loaded_label_dictionary.Add(label, handle);
                handle.WaitForCompletion();
                return handle.Result;
            }
        }

        /// <summary>
        /// Label 해제
        /// </summary>
        /// <param name="label"></param>
        public void ReleaseLabel(ResourceLabelName label) {
            if (_loaded_label_dictionary.ContainsKey(label)) {
                var handle = _loaded_label_dictionary[label];
                Addressables.Release(handle);
                _loaded_label_dictionary.Remove(label);
            }
        }
    }
}
