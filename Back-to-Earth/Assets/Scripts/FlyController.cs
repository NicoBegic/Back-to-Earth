using UnityEngine;
using System.Collections;

public class FlyController : MonoBehaviour 
{
    private Animator animator;
    private float timer;
    private float speed = 15f;
    private bool gameStarted = false;

	void Start () 
    {
        animator = GetComponent<Animator>();
	}
	
	void Update () 
    {
        if (gameStarted)
        {
            timer += Time.deltaTime;
        }
        Fly();
	}

    void Fly()
    {
        if (timer > 3)
        {
            transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }

        if (timer > 5)
        {
            animator.SetBool("IsFlying", true);
        }
    }

    public void GameStarted()
    {
        gameStarted = true;
    }
}
