using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;

    private static SoundController instance = null;

    public static SoundController Instance
    {
        get { return instance; }
    }

    void Awake() 
    {
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
            return;
        } 
        else 
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
    }
}
