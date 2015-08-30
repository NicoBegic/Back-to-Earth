using UnityEngine;
using System.Collections;

public abstract class Platform
{
    public abstract void Handle(GameObject player);

    public abstract void Exit(GameObject player);
}
