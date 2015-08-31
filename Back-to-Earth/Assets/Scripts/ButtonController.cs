using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour 
{
    public Button ExitButton;
    private Button button;

	void Start () 
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { DeactivateButton(); });
	}

    private void DeactivateButton()
    {
        ExitButton.enabled = false;
        button.enabled = false;
    }
}
