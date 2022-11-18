using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    AssetReference sceneReference;

    public void Load()
    {
        if (string.IsNullOrEmpty(sceneReference.AssetGUID))
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        else
            sceneReference.LoadSceneAsync();
    }
}
