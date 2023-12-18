using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject MainMenuPanel;
    public GameObject ratingPanel;
    public GameObject upgradePanel;
    public GameObject FaQPanel;
    public GameObject LevelSelectionPanel;

    public Text coinText;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        if (coinText != null)
        {
            UpdateCoinText();
        }
    }

    private void UpdateCoinText()
    {
        // Display the total coins in the MainMenu coin text
        coinText.text = gameManager.GetTotalCoins().ToString();
    }
    /*----------Level Selection Panel----------*/

    public void OpenLSPanel()
    {
        LevelSelectionPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void CloseLSPanel()
    {
        LevelSelectionPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    /*----------Settings Panel----------*/
    public void OpenSettingsPanel()
    {
        settingPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void CloseSettingsPanel()
    {
        settingPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    /*----------Rating Panel----------*/
    public void OpenRatingPanel()
    {
        ratingPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void CloseRatingPanel()
    {
        ratingPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    /*----------Upgrade Panel----------*/
    public void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void CloseUpgradePanel()
    {
        upgradePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    /*----------FaQ Panel----------*/
    public void OpenFAQPanel()
    {
        FaQPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void CloseFAQPanel()
    {
        FaQPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

   

    /*----------Level Selection----------*/
    
    public void Level1()
    {
        SceneManager.LoadScene(3);
    }
    public void Level2()
    {
        SceneManager.LoadScene(4);
    }
    public void Endless()
    {
        SceneManager.LoadScene(2);
    }

}
