using UnityEngine;
using System.Collections;

public class PlatformControler : MonoBehaviour
{
    public GameObject Chunk;

    private Platform platformType;

    public Platform PlatformType 
    {
        get { return platformType; }
        set { platformType = value; } 
    }

	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}

    //doesnt work!
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Bums");
        if (!collision.collider.gameObject.Equals(this.gameObject) && collision.collider.gameObject.tag == this.gameObject.tag)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        //float newPositionX = Chunk.transform.position.x + Random.Range(-Chunk.GetComponent<BoxCollider>().bounds.size.x / 2, Chunk.GetComponent<BoxCollider>().bounds.size.x / 2);
        float newPositionX = Chunk.transform.position.x + Random.Range(-Chunk.transform.localScale.x /2, Chunk.transform.localScale.x /2);
        this.transform.position = new Vector3(newPositionX, this.transform.position.y, this.transform.position.z);
    }
}
