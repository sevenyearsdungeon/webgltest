using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class LoadAddressable : MonoBehaviour
{
    [SerializeField]
    AssetReferenceGameObject objectToLoad;

    [SerializeField]
    Slider progress;
    IEnumerator Start()
    {
        var op = objectToLoad.InstantiateAsync();
        while (!op.IsDone)
        {
            if (progress != null) progress.value = op.PercentComplete;
            yield return null;
        }
    }
}
