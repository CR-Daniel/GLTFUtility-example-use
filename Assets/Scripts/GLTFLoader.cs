using Siccity.GLTFUtility;
using UnityEngine;

public class GLTFLoader : MonoBehaviour
{
    public string relativeFilePath = "tree01.gltf";

    void Start()
    {
        string absoluteFilePath = System.IO.Path.Combine(Application.streamingAssetsPath, relativeFilePath);

        Importer.LoadFromFileAsync(absoluteFilePath, new ImportSettings(), OnFinishAsync);
    }

    void OnFinishAsync(GameObject result, AnimationClip[] animations)
    {
        if(result != null)
        {
            Instantiate(result, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("Failed to load the glTF file.");
        }
    }
}
