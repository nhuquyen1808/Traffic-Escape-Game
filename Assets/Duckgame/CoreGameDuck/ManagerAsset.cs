using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
/*using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;*/

namespace DevDuck
{
    public static class ManagerAsset
    {
        // push this function on SceneStart Game to download addessable then use them
      /*  public static void initAddresable()
        {
            Addressables.InitializeAsync();
        }
        public static bool IsAssetExist(string addressableName, System.Type assetType)
        {
            // Get the list of ResourceLocators in Addressable
            var locators = Addressables.ResourceLocators;
            // Check if the asset is in any ResourceLocator
            foreach (IResourceLocator locator in locators)
            {
                if (locator.Locate(addressableName, assetType, out var locations) && locations.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static async Task<T> LoadAsset<T>(string key)
        {
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(key);
            await handle.Task;
            T asset = default;
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                asset = handle.Result;
            }
            else
            {
                // Debug.LogError($"Failed to load asset of type {typeof(T)} with key: {key}");
            }
            Addressables.Release(handle);
            return asset;
        }

        public static void ReleaseAssetByKey(string key)
        {
            Addressables.Release(key);
        }*/

        public static void LoadAsset(string assetPath)
        {

            object asset = Resources.Load(assetPath);

            if (asset == null)
            {
                Debug.LogError("Asset not exist: " + assetPath);
            }
            else
            {
                Debug.Log("asset loaded : " + assetPath);
                
            }
        }

    }

}
