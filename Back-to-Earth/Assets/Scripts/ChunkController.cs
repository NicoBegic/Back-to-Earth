using UnityEngine;
using System.Collections;

public class ChunkController : MonoBehaviour
{
    public GameObject[] Platforms;

    public GameObject Player;
    public GameObject NextChunk;

    public int RowCount;
    public float MinFallDistance;
    public float MaxFallDistance;

    private bool loaded;
    private BoxCollider boxCollider;
    private GameObject latestPlatform;
    private int randomPlatform;

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

        latestPlatform = new GameObject();

        for (int p = 0; p < Random.Range(1, MaxPlatformsInRow()); p++)
        {
            randomPlatform = Random.Range(0, Platforms.Length);
            float firstposX = this.transform.position.x + Random.Range(-this.boxCollider.bounds.size.x / 2, this.boxCollider.bounds.size.x / 2);
            float firstposY = this.transform.position.y + (Mathf.Sin(this.transform.rotation.eulerAngles.x) / (this.boxCollider.bounds.size.z / 2)) - Random.Range(this.MinFallDistance, MaxFallDistance);
            float firstposZ = this.transform.position.z - this.boxCollider.bounds.size.z / 2;
            Instantiate(Platforms[randomPlatform], new Vector3(firstposX, firstposY, firstposZ), Quaternion.identity);
            this.Platforms[randomPlatform].transform.position = new Vector3(firstposX, firstposY, firstposZ);
        }

        latestPlatform.transform.position = Platforms[randomPlatform].transform.position;

        for (int i = 0; i < RowCount; i++)
         {
            for (int t = 0; t < Random.Range(1, MaxPlatformsInRow()); t++)
            {
                CreatePlatform();
            }

            latestPlatform.transform.position = Platforms[randomPlatform].transform.position;
        }
    }

    private void CreatePlatform()
    {
        randomPlatform = Random.Range(0, Platforms.Length);

        float positionX = this.transform.position.x + Random.Range(-this.boxCollider.bounds.size.x / 2, this.boxCollider.bounds.size.x / 2);
        float positionY = latestPlatform.transform.position.y - (Platforms[randomPlatform].GetComponent<BoxCollider>().bounds.size.y) - Random.Range(MinFallDistance, MaxFallDistance);
        float positionZ = latestPlatform.transform.position.z + (Platforms[randomPlatform].GetComponent<BoxCollider>().bounds.size.z) + CalculateMaxPlatformDistance(); //Random.Range(CalculateMinPlatformDistance(), CalculateMaxPlatformDistance());

        Instantiate(Platforms[randomPlatform], new Vector3(positionX, positionY, positionZ), Quaternion.identity);
        Platforms[randomPlatform].transform.position = new Vector3(positionX, positionY, positionZ);
    }

    private int MaxPlatformsInRow()
    {
        BoxCollider box = Platforms[randomPlatform].GetComponent<BoxCollider>();
        float maxPlatforms = this.boxCollider.bounds.size.x / box.size.x;
        
        return (int)maxPlatforms;
    }

    private float CalculateMaxPlatformDistance()
    {
        BoxCollider box = Platforms[randomPlatform].GetComponent<BoxCollider>();

        float maxDistance = (this.boxCollider.bounds.size.z - (RowCount * box.size.z)) / RowCount;
        return maxDistance;
    }

    private float CalculateMinPlatformDistance()
    {
        BoxCollider box = Platforms[randomPlatform].GetComponent<BoxCollider>();

        float minDistance = box.size.z;

        return minDistance;
    }

    private void InitChunk()
    {
        Instantiate(NextChunk, this.transform.position + new Vector3(0, -this.boxCollider.bounds.size.y , this.boxCollider.bounds.size.z ), this.transform.rotation);
    }
}
