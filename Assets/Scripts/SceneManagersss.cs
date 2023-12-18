using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagersss : MonoBehaviour
{
    public GameObject PausePanel, PauseButton, twoPanels;
    void Update()
    {
        
    }

    public void Pause() 
    {
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
        twoPanels.SetActive(false);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
        twoPanels.SetActive(true);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }


}
