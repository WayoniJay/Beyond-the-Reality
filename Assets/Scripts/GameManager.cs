using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public float timeLeft = 60f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    //public GameObject winPanel;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);

        if (timeLeft <= 0)
        {
            EndGame();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    void EndGame()
    {
        //winPanel.SetActive(true);
    }
}
