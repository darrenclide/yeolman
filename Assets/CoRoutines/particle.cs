using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a") == true)
        {
            target.gameObject.SetActive(true);
        }
        else
        {
            target.gameObject.SetActive(false);
        }
    }
}
