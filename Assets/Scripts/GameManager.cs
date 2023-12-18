using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int totalCoins = 0;
    private string totalCoinsKey = "TotalCoins";

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Load the total number of coins from PlayerPrefs when the game starts
        LoadTotalCoins();
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        SaveTotalCoins();
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    private void SaveTotalCoins()
    {
        // Save the total number of coins to PlayerPrefs
        PlayerPrefs.SetInt(totalCoinsKey, totalCoins);
        PlayerPrefs.Save();
    }

    private void LoadTotalCoins()
    {
        // Load the total number of coins from PlayerPrefs
        if (PlayerPrefs.HasKey(totalCoinsKey))
        {
            totalCoins = PlayerPrefs.GetInt(totalCoinsKey);
        }
    }
}
