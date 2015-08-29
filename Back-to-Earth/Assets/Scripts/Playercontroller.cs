using UnityEngine;
using System.Collections;

public class Playercontroller : MonoBehaviour 
{
    public float MovementSpeed = 2f;
    public float JumpSpeed = 500f;

    private bool isGrounded;

    void Update()
    {
        Move();
        Jump();
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    private void Animate()
    {
        if (true)
        {
            
        }
    }

    private void Move()
    {
        var v = Input.GetAxis("Horizontal");
        var h = Input.GetAxis("Vertical");
        transform.Translate(v * MovementSpeed * Time.deltaTime, 0, h * MovementSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            GetComponent<Rigidbody>().AddForce(0, JumpSpeed, 0);
            isGrounded = false;
        }
    }
}
