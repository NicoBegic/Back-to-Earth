using UnityEngine;
using System.Collections;

public class Playercontroller : MonoBehaviour 
{
    public float MovementSpeed = 2f;
    public float JumpSpeed = 500f;

    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        this.animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsStaying", true);

        if (collision.gameObject.tag == "Platform")
        {
            GameManager.Points++;
        }
    }

    private void Move()
    {
        var v = Input.GetAxis("Horizontal");
        var h = Input.GetAxis("Vertical");

        if (v != 0 && isGrounded)
        {
            animator.SetBool("IsRunning", true);
        }
        else if (h != 0 && isGrounded)
        {
            animator.SetBool("IsRunning", true);
        }
        else
            animator.SetBool("IsRunning", false);

        transform.Translate(v * MovementSpeed * Time.deltaTime, 0, h * MovementSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsStaying", false);
            GetComponent<Rigidbody>().AddForce(0, JumpSpeed, 0);
            isGrounded = false;
        }
    }
}
