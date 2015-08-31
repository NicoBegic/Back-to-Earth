using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour 
{
    private float timer;
    private bool timerStarted = false;

    void Update()
    {
        if (timerStarted)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 10)
        {
            StartGame();
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public void StartGame()
    {
        GameManager.Points = 0;
        Application.LoadLevel("LevelGeneration");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
