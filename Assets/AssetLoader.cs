using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AssetLoader : MonoBehaviour
{
    [SerializeField] CanvasGroup group;
    [SerializeField] AssetReferenceGameObject earthPrefab, marsPrefab, moonPrefab;
    [SerializeField] Slider progressBar;
    [SerializeField] GameObject loadedPlanet = null;
    AsyncOperationHandle asyncHandle;

    private void EnableUi()
    {
        group.interactable = true;
        group.alpha = 1f;
    }

    private void DisableUi()
    {
        group.interactable = false;
        group.alpha = 0.5f;
    }

    public void OnLoadEarthButtonPressed() => StartLoadingPlanet(earthPrefab);
    public void OnLoadMoonButtonPressed() => StartLoadingPlanet(moonPrefab);
    public void OnLoadMarsButtonPressed() => StartLoadingPlanet(marsPrefab);

    public void StartLoadingPlanet(AssetReferenceGameObject planet)
    {
        DisableUi();
        asyncHandle = planet.InstantiateAsync();
        asyncHandle.Completed += FinishLoadingPlanet;
        progressBar.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (progressBar.gameObject.activeSelf)
        {
            Debug.Log(asyncHandle.PercentComplete);
            progressBar.value = asyncHandle.PercentComplete;
        }
    }

    private void FinishLoadingPlanet(AsyncOperationHandle obj)
    {
        EnableUi();
        UnloadLoadedPlanet();
        var planet = obj.Result as GameObject;
        progressBar.gameObject.SetActive(false);
        loadedPlanet = planet;
    }


    private void UnloadLoadedPlanet()
    {
        if (loadedPlanet != null)
            Destroy(loadedPlanet);
        loadedPlanet = null;
    }
}
