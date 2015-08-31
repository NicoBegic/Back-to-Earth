using UnityEngine;
using System.Collections;

public class Playercontroller : MonoBehaviour 
{
    public float MovementSpeed = 5f;
    public float JumpSpeed = 500f;

    private Animator[] animators;
    private bool isGrounded;
    private bool isDead;
    private bool gameStarted;
    private Rigidbody rigidBody;

    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody>();
        this.animators = GetComponentsInChildren<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        CheckDeath();
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        animators[1].SetBool("IsJumping", false);
        animators[1].SetBool("IsStaying", true);

        if (collision.gameObject.tag == "Platform")
        {
            GameManager.Points += 200;
        }
        if (collision.gameObject.tag == "StartPlatform")
        {
            gameStarted = true;
        }
    }

    private void Move()
    {
        var v = Input.GetAxis("Horizontal");
        var h = Input.GetAxis("Vertical");

        if (v != 0 && isGrounded)
        {
            animators[1].SetBool("IsRunning", true);
        }
        else if (h != 0 && isGrounded)
        {
            animators[1].SetBool("IsRunning", true);
        }
        else
            animators[1].SetBool("IsRunning", false);

        transform.Translate(v * MovementSpeed * Time.deltaTime, 0, h * MovementSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            animators[1].SetBool("IsJumping", true);
            animators[1].SetBool("IsStaying", false);
            rigidBody.AddForce(0, JumpSpeed, 0);
            isGrounded = false;
        }
        if (isGrounded == false && isDead == false && gameStarted)
        {
            GameManager.Points++;
        }
    }

    private void CheckDeath()
    {
        if (GameManager.Platforms.Count > 0)
        {
            if (this.transform.position.y < GameManager.Platforms[GameManager.Platforms.Count - 1].transform.position.y)
            {
                isDead = true;
                GameManager.Platforms.Clear();
                animators[1].SetBool("IsDead", true);
            }
        }
    }
}
