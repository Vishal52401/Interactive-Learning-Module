using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [Header("Quiz Panels")]
    [SerializeField] private GameObject QuizPanel1;
    [SerializeField] private GameObject QuizPanel2;
    [SerializeField] private GameObject QuizPanel3;
    [SerializeField] private GameObject QuizPanel4;
    [SerializeField] private GameObject resultPanal;

    [Header("ScoreText")]
    public TextMeshProUGUI scoreText;
    // Correct Answers
    private string[] quizAns = { "Bottle", "Rock", "Chair", "Apple" };

    // User Answers
    private string[] userAns = new string[4];

    private int currentQuestion = 0;

    public void AppleButton()
    {
        SaveAnswer("Apple");
        
    }

    public void RockButton()
    {
        SaveAnswer("Rock");
        
    }

    public void ChairButton()
    {
        SaveAnswer("Chair");
        
    }

    public void BottleButton()
    {
        SaveAnswer("Bottle");
        
    }

    void SaveAnswer(string answer)
    {
        userAns[currentQuestion] = answer;
        currentQuestion++;

        ShowNextQuestion();

        if (currentQuestion == quizAns.Length)
        {
            CheckScore();
        }
    }

    void ShowNextQuestion()
    {
        QuizPanel1.SetActive(currentQuestion == 0);
        QuizPanel2.SetActive(currentQuestion == 1);
        QuizPanel3.SetActive(currentQuestion == 2);
        QuizPanel4.SetActive(currentQuestion == 3);
    }

    void CheckScore()
    {
        int score = 0;

        for (int i = 0; i < quizAns.Length; i++)
        {
            if (quizAns[i] == userAns[i])
            {
                score++;
            }
        }

        float scoreIn = ((float)score / quizAns.Length) * 100f;

        resultPanal.SetActive(true);
        scoreText.text = "Score : " + score + "/" + quizAns.Length + "\n" +
                         "Percentage : " + scoreIn.ToString("F0") + "%";
    }
    public void RestartQuiz()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}