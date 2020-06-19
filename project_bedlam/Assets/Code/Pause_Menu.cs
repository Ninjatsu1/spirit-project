using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField]
    private GameObject PauseMenuUI;
    //[SerializeField]
    //private GameObject GameOverUI;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   public void Resume()
    {
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void LoadGame()
    {
        //Load latest game save
        Debug.Log("Load game...");
    }
}
