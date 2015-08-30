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
        if (timer >= 5)
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
        //Application.LoadLevel("");#
        Debug.Log("GAMESTARTED");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
