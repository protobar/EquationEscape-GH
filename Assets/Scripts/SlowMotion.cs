using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotion : MonoBehaviour
{
    [Header("Slow Motion")]
    public float slowMotionFactor = 0.1f;
    public float questionDuration = 5f;
    public EnemySpawn eS;

    private bool isInSlowMotion = false;
    private float originalTimeScale;

    [Header("Math Related")]
    public Text questionText;
    public Button option1Button;
    public Button option2Button;
    public Button option3Button;
    public GameObject MathCanvas, CorrectCanvas, FalseCanvas;

    private int correctAnswer;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EnterSlowMotion();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ExitSlowMotion();
        }
    }

    void EnterSlowMotion()
    {
        MathCanvas.SetActive(true);
        CorrectCanvas.SetActive(false);
        FalseCanvas.SetActive(false);

        isInSlowMotion = true;
        originalTimeScale = Time.timeScale;

        Time.timeScale = slowMotionFactor;

        GenerateQuestion();

        StartCoroutine(QuestionTimer());
    }

    void ExitSlowMotion()
    {
        isInSlowMotion = false;
        MathCanvas.SetActive(false);
        CorrectCanvas.SetActive(false);

        // Return to normal time scale
        Time.timeScale = originalTimeScale;
    }

    void GenerateQuestion()
    {
        int num1 = Random.Range(1, 10);
        int num2 = Random.Range(1, 10);
        correctAnswer = num1 + num2;

        questionText.text = $"What is {num1} + {num2}?";

        // Generate a random order for the buttons
        List<Button> buttons = new List<Button> { option1Button, option2Button, option3Button };
        buttons = buttons.OrderBy(x => Random.value).ToList();

        // Assign the correct answer to one of the buttons randomly
        AssignAnswerToButton(correctAnswer, buttons[0]);

        // Assign incorrect answers to the other buttons
        AssignAnswerToButton(GenerateWrongAnswer(correctAnswer), buttons[1]);
        AssignAnswerToButton(GenerateWrongAnswer(correctAnswer), buttons[2]);
    }

    void AssignAnswerToButton(int answer, Button button)
    {
        button.GetComponentInChildren<Text>().text = answer.ToString();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => OnButtonClick(answer));
    }

    int GenerateWrongAnswer(int correctAnswer)
    {
        int wrongAnswer = correctAnswer;

        while (wrongAnswer == correctAnswer)
        {
            wrongAnswer = Random.Range(1, 20);
        }

        return wrongAnswer;
    }

    void OnButtonClick(int selectedAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            Debug.Log("Correct! Player survives.");
            CorrectCanvas.SetActive(true);

            // Move the enemy downward
            MoveEnemyDown();
        }
        else
        {
            Debug.Log("Incorrect. Player is destroyed!");
            FalseCanvas.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    void MoveEnemyDown()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Vector3 targetPosition = new Vector3(enemy.transform.position.x, -42f, enemy.transform.position.z);
            StartCoroutine(SmoothMove(enemy.transform, targetPosition, 2f)); 
        }
    }

    IEnumerator SmoothMove(Transform transform, Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure that the final position is exactly the target position
        transform.position = targetPosition;
    }

    IEnumerator QuestionTimer()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(questionDuration);

        // If the question timer expires, treat it as an incorrect answer
        Debug.Log("Time's up! Player is destroyed!");
        // Handle player destruction here (e.g., destroy the player GameObject)
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        // Exit slow-motion regardless of the answer
        ExitSlowMotion();
    }

    
}
