using UnityEngine;
using System.Collections;

public class Playercontroller : MonoBehaviour 
{
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime));
        }
	}
}
