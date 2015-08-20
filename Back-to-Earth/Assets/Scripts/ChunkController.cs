using UnityEngine;
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

    void Start()
    {
        transform.localScale = new Vector3(25, 25, 50);
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

        GameObject latestPlatform = new GameObject();

        float firstposX = this.transform.position.x + Random.Range(-this.transform.localScale.x / 2, this.transform.localScale.x / 2);
        float firstposY = this.transform.position.y + ((this.transform.localScale.z /2) / Mathf.Cos(this.transform.rotation.eulerAngles.x));
        float firstposZ = this.transform.position.z - this.transform.localScale.z /2;
        Instantiate(Platform, new Vector3(firstposX, firstposY, firstposZ), Quaternion.identity);

        latestPlatform = Platform;

        for (int i = 0; i < RowCount; i++)
        {
            for (int t = 0; t < Random.Range(1, MaxPlatformsInRow); t++)
            {
                float positionX = this.transform.position.x + Random.Range(-this.transform.localScale.x / 2, this.transform.localScale.x / 2);
                float positionY = latestPlatform.transform.position.y - (latestPlatform.transform.localScale.z / 2) - Random.Range(MinFallDistance, MaxFallDistance);
                float positionZ = latestPlatform.transform.position.z + (latestPlatform.transform.localScale.z / 2) + Random.Range(MinPlatformDistance, MaxPlatformDistance);

                Instantiate(Platform, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
            }

            latestPlatform = Platform;
        }
    }

    private void InitChunk()
    {
        Instantiate(NextChunk, this.transform.position + new Vector3(0, -this.transform.localScale.y / 2, this.transform.localScale.z / 2), this.transform.rotation);
    }
}
