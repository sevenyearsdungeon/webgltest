using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableLoader : MonoBehaviour
{
    public AssetReference blueMaterial;
    public AssetReference cubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        cubePrefab.LoadAssetAsync<GameObject>().Completed += AddressableLoader_Completed; ;
    }

    GameObject createdObject;

    private void AddressableLoader_Completed(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        createdObject = Instantiate(obj.Result);
        createdObject.transform.position = Vector3.zero;

        blueMaterial.LoadAssetAsync<Material>().Completed += (m) =>
          {
              createdObject.GetComponentInChildren<Renderer>().material = m.Result;
          };
    }

    private void Update()
    {
        if (createdObject != null)
        {
            createdObject.transform.Rotate(Vector3.up * Time.deltaTime * 30);
        }
    }
}
