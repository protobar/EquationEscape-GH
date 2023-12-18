using UnityEngine;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{
    public Image progressBar;
    public GameObject levelCompletePanel;
    public Text scoreText;

    public float maxSurvivalTime = 10f;
    private float currentSurvivalTime = 0f;
    private bool levelComplete = false;

    private void Update()
    {
        if (!levelComplete)
        {
            currentSurvivalTime += Time.deltaTime;

            // Calculate progress percentage based on the current survival time
            float progress = Mathf.Clamp01(currentSurvivalTime / maxSurvivalTime);

            // Update the progress bar
            progressBar.fillAmount = progress;

            // Display progress percentage as integers
            int percentage = Mathf.FloorToInt(progress * 100);

            // Display the percentage or any other UI representation
            // (You may customize this based on your UI design)
            Debug.Log("Player Progress: " + percentage + "%");

            // Update score based on progress (2 points for every 1%)
            int score = Mathf.FloorToInt(progress * 100 * 2);
            UpdateScore(score);

            // Check if the progress bar is full
            if (progress >= 1f)
            {
                levelComplete = true;
                ShowLevelCompletePanel();
            }
        }
    }

    private void UpdateScore(int newScore)
    {
        // Update the score and display it
        scoreText.text = newScore.ToString();
    }

    private void ShowLevelCompletePanel()
    {
        // Display the level complete panel or perform any other actions
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0;

    }
}
