using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public GameObject gameOver;
    public GameObject playButton;

    public int score;
    public Text scoreText;
    AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        audioManager.PlaySFX(audioManager.background);
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Fence[] fences = FindObjectsOfType<Fence>();

        for (int i = 0; i < fences.Length; i++)
        {
            Destroy(fences[i].gameObject);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {        
        playButton.SetActive(true);
        gameOver.SetActive(true);
        Pause();
    }

}
