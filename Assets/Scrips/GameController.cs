using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public Text Point;
    public Text YourPoint;
    int GamePoint = 0;
    AudioSource Audio;
    private float startTime;
    public Text Timer;
    string timerString;
    public Text GameTime;

    // Start is called before the first frame update
    void Start()
    {
        StartG.SetActive(true);
        End.SetActive(false);
        Time.timeScale = 0;
        Audio = gameObject.GetComponent<AudioSource>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    public void UpdateTime()
    {
        float currentTime = Time.time - startTime;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        Timer.text = "Time: " + timerString;
    }
    public void GetPoint()
    {
        GamePoint++;
        Point.text = "Boom: " + GamePoint.ToString();
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
        YourPoint.text = "Boom: " + GamePoint.ToString();
    }
}
