using UnityEngine;
using System.Collections;

public class IcePlatform : Platform
{
    public override void Handle(GameObject player)
    {
        player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 30));
    }

    public override void Exit(GameObject player)
    {
    }
}
