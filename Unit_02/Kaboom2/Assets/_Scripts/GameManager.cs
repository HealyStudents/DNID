using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lives = 3;
    public int score = 0;
    public TextMeshProUGUI scoreText, gameOverText;
    public PlayerController player;
    public Bomber bomber;
    public int level = 1;

    public bool isPaused;
    public GameObject menu;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InvokeRepeating("IncreaseLevel", 5f, 5f);
    }

    private void FixedUpdate()
    {
        scoreText.text = "" + score;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPauseMenu();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowPauseMenu()
    {
        isPaused = !isPaused;
        menu.SetActive(isPaused);
    }

    public void IncreaseLevel()
    {
        level++;
        bomber.bomberSpeed *= 1.2f;
        bomber.bombWaitTime *= 0.9f;
    }

    public void CatchBomb()
    {
        score += 10 * level;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
    }

    public void KillPlayer()
    {
        AudioManager.instance.PlaySound("explosion");

        lives--;
        if (lives <= 0)
        {
            GameOver();
            return;
        }
        Destroy(player.transform.GetChild(player.transform.childCount - 1).gameObject);
    }    
}
