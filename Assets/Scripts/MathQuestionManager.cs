/*using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MathQuestionManager : MonoBehaviour
{
    public Text questionText;
    public Button option1Button;
    public Button option2Button;
    public Button option3Button;

    private int correctAnswer;

    void Start()
    {
        InitializeQuiz();
    }

    void InitializeQuiz()
    {
        int num1 = Random.Range(1, 10);
        int num2 = Random.Range(1, 10);
        correctAnswer = num1 + num2;

        questionText.text = $"What is {num1} + {num2}?";

        AssignAnswerToButton(correctAnswer, option1Button);
        AssignAnswerToButton(GenerateWrongAnswer(correctAnswer), option2Button);
        AssignAnswerToButton(GenerateWrongAnswer(correctAnswer), option3Button);
    }

    void AssignAnswerToButton(int answer, Button button)
    {
        button.GetComponentInChildren<Text>().text = answer.ToString();
        button.onClick.RemoveAllListeners(); // Clear existing listeners
        button.onClick.AddListener(() => OnButtonClick(answer));
    }

    void OnButtonClick(int selectedAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Incorrect. Try again!");
        }

        InitializeQuiz(); // Initialize the next question
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
}
*/