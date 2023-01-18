using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuFromGame : MonoBehaviour
{
    public GameObject pausePanel;
    public void pauseMenu(){
        pausePanel.SetActive(true);
    }
    public void resume(){
        pausePanel.SetActive(false);
    }
    public void exit(){
        Application.Quit();
    }
}
