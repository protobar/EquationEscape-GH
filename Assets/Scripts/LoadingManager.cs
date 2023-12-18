using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public float minTime = 1f;
    public float maxTime = 1f;
    private bool timeUp = false;

    public Image loadingImg;
    public Text loadingText;
    float randomTime;
    private float currentTime;

    private void Start()
    {
        randomTime = Random.Range(minTime, maxTime);
        Invoke("LoadingScreen", randomTime);
    }

    void Update()
    {
        if (currentTime < randomTime)
        {
            currentTime += Time.deltaTime;
            float fillAmount = currentTime / randomTime;
            loadingImg.fillAmount = fillAmount;

            // Display loading percentage as integers
            int percentage = Mathf.FloorToInt(fillAmount * 100);
            loadingText.text = percentage + " %";
        }
        else
        {
            if (!timeUp)
            {
                timeUp = true;
                loadingImg.fillAmount = 1f;
                loadingText.text = "100 %";
                SceneManager.LoadScene(1);
            }
        }
    }

    void LoadingScreen()
    {
        SceneManager.LoadScene(1);
    }
}
