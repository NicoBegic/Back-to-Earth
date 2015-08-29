using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    private int fallTime = 100;
    private int timer;

	void Update () 
    {
        timer++;
        CheckFallTime();
	}

    private void CheckFallTime()
    {
        if (timer == fallTime)
        {
            GameManager.Platforms[0].Falls = true;
            GameManager.Platforms[0].Fall();
            timer = 0;
        }
    }
}
