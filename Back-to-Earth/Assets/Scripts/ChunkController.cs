﻿using UnityEngine;
using System.Collections;

public class ChunkController : MonoBehaviour
{
    public GameObject Player;
    public GameObject NextChunk;
    public GameObject Platform;

    public int RowCount;
    public float MaxPlatformsInRow;
    public float MinPlatformDistance;
    public float MaxPlatformDistance;
    public float MinFallDistance;
    public float MaxFallDistance;

    private bool loaded;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        transform.localScale = new Vector3(25, 10, 50);
    }

    void Update()
    {
        if (loaded == false)
        {
            CheckInSight();
        }
    }

    private void CheckInSight()
    {
        if (Player.GetComponentInChildren<Camera>().farClipPlane  + Player.transform.position.z 
            >= this.transform.position.z - (this.transform.localScale.z / 2))
        {
            LoadChunk();
            loaded = true;
        }
    }

    private void LoadChunk()
    {
        InitChunk();

        GameObject latestPlatform;

        float firstposX = this.transform.position.x + Random.Range(-this.boxCollider.bounds.size.x / 2, this.boxCollider.bounds.size.x / 2);
        float firstposY = this.transform.position.y + (Mathf.Sin(this.transform.rotation.eulerAngles.x) / (this.boxCollider.bounds.size.z /2));
        float firstposZ = this.transform.position.z - this.boxCollider.bounds.size.z / 2;
        Instantiate(Platform, new Vector3(firstposX, firstposY, firstposZ), Quaternion.identity);
        this.Platform.transform.position = new Vector3(firstposX, firstposY, firstposZ);

        latestPlatform = Platform;

        for (int i = 0; i < RowCount; i++)
        {
            for (int t = 0; t < Random.Range(1, MaxPlatformsInRow); t++)
            {
                float positionX = this.transform.position.x + Random.Range(-this.boxCollider.bounds.size.x /2, this.boxCollider.bounds.size.x /2);
                float positionY = latestPlatform.transform.position.y - (latestPlatform.GetComponent<BoxCollider>().bounds.size.y) - Random.Range(MinFallDistance, MaxFallDistance);
                float positionZ = latestPlatform.transform.position.z + (latestPlatform.GetComponent<BoxCollider>().bounds.size.z) + Random.Range(MinPlatformDistance, MaxPlatformDistance);

                Instantiate(Platform, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
                Platform.transform.position = new Vector3(positionX, positionY, positionZ);
               
            }

            latestPlatform = Platform;
        }
    }

    private void InitChunk()
    {
        Instantiate(NextChunk, this.transform.position + new Vector3(0, -this.boxCollider.bounds.size.y , this.boxCollider.bounds.size.z ), this.transform.rotation);
    }
}
