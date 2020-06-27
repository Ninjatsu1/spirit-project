using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour
{
    //private int sceneIndex = 2;
    public Slider slider = null;
    [SerializeField]
    private GameObject LoadingCanvas = null;
    private void Start()
    {
        
    }
   public void LoadScene(int sceneIndex)
    {
        LoadingCanvas.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));

    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
