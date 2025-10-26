using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public float timeLeft = 60f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public string portalColor; // e.g. "Blue", "Gold", "Purple"
    public int points = 10;


    [Header("UI Elements")]
    public GameObject menuPanel;
    public GameObject winPanel;
 
    public AudioClip successSound;
    public AudioClip failSound;
    public AudioClip background;

    private AudioSource audioSource;
    private GameManager gameManager;
    //public GameObject winPanel;

    private bool gameEnded = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        //UpdateUI();
        //winPanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            EndGame();
        }

        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();

        if (score >= 100)
        {
            EndGame();
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }

    void EndGame()
    {
        gameEnded = true;
        //winPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        ColorMatch orb = other.GetComponent<ColorMatch>();

        if (orb != null)
        {
            if (orb.colorTag == portalColor)
            {
                gameManager.AddScore(10); // faster than FindObjectOfType
                if (successSound) audioSource.PlayOneShot(successSound);
                Destroy(other.gameObject);
            }
            else
            {
                gameManager.AddScore(-5);
                if (failSound) audioSource.PlayOneShot(failSound);
            }
        }
    }
}