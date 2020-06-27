using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private int SceneToLoad = 1;
    public Button button;
    private void Awake()
    {
        button.onClick.AddListener(Load);
    }
    public void Load()
    {
        FindObjectOfType<LevelLoader>().LoadScene(SceneToLoad);
    }
}
