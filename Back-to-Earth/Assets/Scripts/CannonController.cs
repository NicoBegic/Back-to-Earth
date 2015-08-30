using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour 
{
    private Animator animator;
    private float timer;
    public GameObject cannonSmoke;
    private bool gameStarted = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameStarted)
        {
            timer += Time.deltaTime;
        }
        Shoot();
    }

    void Shoot()
    {
        if (timer > 2)
        {
            animator.SetBool("IsShootable", true);
            cannonSmoke.SetActive(true);
        }
    }

    public void GameStarted()
    {
        gameStarted = true;
    }
}
