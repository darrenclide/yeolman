using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lightscript : MonoBehaviour
{
    public GameObject ourLight;
    public bool handRaise;
    float charge;
    float chargeCost;
    public Slider slider;
    public void SetCharge(float charge)
    {
        slider.value = charge;
    }
    // Start is called before the first frame update
    void Start()
    {
        charge = 100f;
        chargeCost = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        SetCharge(charge);
        print("charge: "+charge);
        if(Input.GetKey("f") || Input.GetKey(KeyCode.Keypad4))
        {
            handRaise = true;
        }
        else
        {
            handRaise = false;  
        }
        if (Input.GetKey(KeyCode.Mouse0) == true && handRaise == true && charge > 0)
        {
            charge -= chargeCost * Time.deltaTime;
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
