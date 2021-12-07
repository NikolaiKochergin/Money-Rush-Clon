using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    private GameObject _loadedLevelObjects;

    public event UnityAction LevelLoaded;

    public void Load()
    {
        if (_loadedLevelObjects)
            Addressables.ReleaseInstance(_loadedLevelObjects);

        Addressables.InstantiateAsync("LevelObjects").Completed += handle =>
        {
            _loadedLevelObjects = handle.Result;
            LevelLoaded?.Invoke();
        };
    }
}
