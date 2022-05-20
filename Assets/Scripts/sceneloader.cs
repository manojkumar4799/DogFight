using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{

    int sceneLoader;
    private void Start()
    {
        sceneLoader = SceneManager.GetActiveScene().buildIndex;
    }
    
    public void LoadNextScene()
    {
      SceneManager.LoadScene(sceneLoader + 1);
    }
    public void ResartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneLoader);
    }
   

    public void QuitApp()
    {
        Application.Quit();
    }
    public void gameover()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("gameover");
    }
}
