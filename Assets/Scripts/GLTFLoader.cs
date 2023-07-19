using Siccity.GLTFUtility;
using UnityEngine;
using UnityEngine.UI;

public class GLTFLoader : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    private string relativeFilePath = "tree01.gltf";

    private void Start()
    {
        string absoluteFilePath = System.IO.Path.Combine(Application.streamingAssetsPath, relativeFilePath);

        Importer.LoadFromFileAsync(absoluteFilePath, new ImportSettings(), OnFinishAsync, OnProgress);
    }

    private void OnFinishAsync(GameObject result, AnimationClip[] animations)
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

    private void OnProgress(float progress)
    {
        progressBar.value = progress;
    }
}
