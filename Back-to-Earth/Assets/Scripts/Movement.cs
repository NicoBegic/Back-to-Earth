using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
    public float MovementSpeed = 2f;
    public float JumpSpeed = 500f;

    private bool isGrounded;
    public bool doubleJump = false;

	void Update () 
    {
        Move();
        Jump();
	}

    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    private void Move()
    {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");
        transform.Translate(h * MovementSpeed * Time.deltaTime, 0, v * MovementSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            if (doubleJump)
            {
                GetComponent<Rigidbody>().AddForce(0, JumpSpeed, 0);
                doubleJump = false;
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(0, JumpSpeed, 0);
                isGrounded = false;
            }
        }
    }
}
