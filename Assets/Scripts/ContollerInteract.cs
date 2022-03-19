using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContollerInteract : MonoBehaviour
{
    public enum ControllerButton : byte
    {
        None = 0, Left = 1, Middle = 2, Right = 3,
    }

    public float Timer;
    private Image img;
    public ControllerButton HighlightButton;
    // Start is called before the first frame update
    void Start()
    {
        img = transform.Find("Loader").GetComponent<Image>();
        img.fillAmount = 0;
        switch (HighlightButton)
        {
            case ControllerButton.Right:
                transform.Find("Right").GetComponent<SpriteRenderer>().enabled = true;
                break;
            case ControllerButton.Middle:
                transform.Find("Middle").GetComponent<SpriteRenderer>().enabled = true;
                break;
            case ControllerButton.Left:
                transform.Find("Left").GetComponent<SpriteRenderer>().enabled = true;
                break;
            case ControllerButton.None:
            default:
                break;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (HighlightButton != ControllerButton.None && Input.GetKey($"{(byte) HighlightButton}"))
        {
            img.fillAmount += Time.deltaTime * (1 / Timer);
            if (img.fillAmount == 1)
                Debug.Log("Clicked");
        }
        else
            img.fillAmount -= Time.deltaTime *  (3 / Timer);
    }
}
