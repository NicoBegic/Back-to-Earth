using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsController : MonoBehaviour
{
    private Text text;
	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        UpdateText();
	}

    private void UpdateText()
    {
        if (GameManager.Points > 0)
        {
            text.text = string.Format("Points : {0}", GameManager.Points);
        }
    }
}
