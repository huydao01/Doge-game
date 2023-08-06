using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject End;
    public GameObject StartG;
    public Button Restart;
    public Button GameStart;
    public Button Quit;
    AudioSource Audio;

    private float startTime;
    public Text Timer;
    public Text GameTime;
    public Text HighScore;
    string timerString;
    float currentTime = 0;
    float highscore = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        StartG.SetActive(true);
        End.SetActive(false);
        Time.timeScale = 0;
        Audio = gameObject.GetComponent<AudioSource>();
        startTime = Time.time;
        highscore = PlayerPrefs.GetFloat("Score");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    public void UpdateTime()
    {
        currentTime = Time.time - startTime;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        Timer.text = "Time: " + timerString;
    }
    public void Highscore()
    {
        if (currentTime > highscore)
        {
            PlayerPrefs.SetFloat("Score", currentTime);
            PlayerPrefs.SetString("Time", timerString);
            HighScore.text = "HighScore: " + timerString;
        }
        else
        {
            string hightime = PlayerPrefs.GetString("Time");
            HighScore.text = "HighScore: " + hightime;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Ready()
    {
        StartG.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void EndGame()
    {
        Audio.Play();
        Time.timeScale = 0;
        End.SetActive(true);
        GameTime.text = "Your Score: " + timerString;
        Highscore();
    }
}
