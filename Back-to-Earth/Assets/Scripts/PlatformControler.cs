using UnityEngine;
using System.Collections;

public class PlatformControler : MonoBehaviour
{
    public GameObject Chunk;

    private Platform platformType;
    private Rigidbody rigidbody;

    public bool Falls;
    private int timer = 100;
    private bool stepped;

    public Platform PlatformType 
    {
        get { return platformType; }
        set { platformType = value; } 
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        GameManager.AddPlatform(this);
    }

    void Update()
    {
        ActualiseLifeTime();
    }

    void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.Equals(this.gameObject) && collision.collider.gameObject.tag == this.gameObject.tag 
            && Falls == false && collision.gameObject.GetComponent<PlatformControler>().Falls == false)
        {
            Reposition();
        }
        if (collision.gameObject.tag == "Player")
        {
            stepped = true;
            Falls = true;
        }
    }

    private void ActualiseLifeTime()
    {
        if (stepped)
        {
            timer--;
        }
        if (timer <= 0)
        {
            Fall();
        }
    }

    public void Fall()
    {
        this.rigidbody.constraints = RigidbodyConstraints.None;
        GameManager.RemovePlatform(this);
    }

    private void Reposition()
    {
        float newPositionX = Chunk.transform.position.x + Random.Range(-Chunk.transform.localScale.x /2, Chunk.transform.localScale.x /2);
        this.transform.position = new Vector3(newPositionX, this.transform.position.y, this.transform.position.z);
    }
}
