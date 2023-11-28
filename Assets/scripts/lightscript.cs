using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightscript : MonoBehaviour
{
    public GameObject ourLight;
    public bool handRaise;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("f") || Input.GetKey(KeyCode.Keypad4))
        {
            handRaise = true;
        }
        else
        {
            handRaise = false;  
        }
        if (Input.GetKey(KeyCode.Mouse0) == true && handRaise == true)
        {
            show();
        }
        else
        {
            hide();
        }
    }
    void show()
    {
        ourLight.SetActive(true);
    }
    void hide()
    {
        ourLight.SetActive(false);
    }
}
