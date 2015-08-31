using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    private int fallTime = 200;
    private int timer;

	void Update () 
    {
        timer++;
        CheckFallTime();
	}

    private void CheckFallTime()
    {
        if (timer == fallTime && GameManager.Platforms.Count > 0)
        {
            GameManager.Platforms[0].Falls = true;
            GameManager.Platforms[0].Fall();
            if (fallTime > 50)
            {
                fallTime -= 5;
            }
            timer = 0;
        }
    }
}
