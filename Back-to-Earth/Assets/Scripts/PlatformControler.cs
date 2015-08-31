using UnityEngine;
using System.Collections;

public class PlatformControler : MonoBehaviour
{
    public GameObject Chunk;

    private Platform platformType;
    private Rigidbody rigidbody;

    public bool Falls;
    private int timer = 30;
    private bool stepped;

    public Platform PlatformType 
    {
        get { return platformType; }
        set { platformType = value; } 
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        GameManager.AddPlatform(this);
        SetPlatformType();
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
            //if (stepped == false)
            //{
            //    platformType.Handle(collision.gameObject);
            //}

            platformType.Handle(collision.gameObject);
            stepped = true;
            Falls = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            platformType.Exit(collision.gameObject);
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

    private void SetPlatformType()
    {
        if (GameManager.PlatformType == 0)
            PlatformType = new EarthPlatform();
        else if (GameManager.PlatformType == 1)
            PlatformType = new IcePlatform();
        else if (GameManager.PlatformType == 2)
            PlatformType = new SandPlatform();
    }
}
