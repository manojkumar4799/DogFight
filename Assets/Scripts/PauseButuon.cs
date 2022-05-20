using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButuon : MonoBehaviour
{
    [SerializeField] GameObject pauseGameobject;
    bool gamePause;
     void Start()
     {
       pauseGameobject.active = false;
     }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                Resume();
            
            }
            else
            {
                pause();
            }
        }
        
        
    }
    void pause()
    {
        gamePause = true;
        pauseGameobject.active = true;
        Time.timeScale = 0f;
    }
    void Resume()
    {
        gamePause = false;
        pauseGameobject.active = false;
        Time.timeScale = 1f;
    }
}
