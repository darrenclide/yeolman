using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightscript : MonoBehaviour
{
    public GameObject ourLight;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f") == true)
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
