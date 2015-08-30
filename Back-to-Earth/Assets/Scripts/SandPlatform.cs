using UnityEngine;
using System.Collections;

public class SandPlatform : Platform
{
    public override void Handle(GameObject player)
    {
        player.GetComponent<Playercontroller>().MovementSpeed = 1.5f;
    }

    public override void Exit(GameObject player)
    {
        player.GetComponent<Playercontroller>().MovementSpeed = 5;
    }
        
}
