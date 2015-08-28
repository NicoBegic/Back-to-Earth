using UnityEngine;
using System.Collections;

public class PlatformControler : MonoBehaviour
{
    public GameObject Chunk;

    private Platform platformType;
    private Rigidbody rigidbody;

    private bool falls;

    public Platform PlatformType 
    {
        get { return platformType; }
        set { platformType = value; } 
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.Equals(this.gameObject) && collision.collider.gameObject.tag == this.gameObject.tag && falls == false)
        {
            Reposition();
        }
        if (collision.gameObject.tag == "Player")
        {

            this.rigidbody.constraints = RigidbodyConstraints.None;
            falls = true;
        }
    }

    private void Reposition()
    {
        float newPositionX = Chunk.transform.position.x + Random.Range(-Chunk.transform.localScale.x /2, Chunk.transform.localScale.x /2);
        this.transform.position = new Vector3(newPositionX, this.transform.position.y, this.transform.position.z);
    }
}
