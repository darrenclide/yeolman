using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cube : MonoBehaviour
{
    float speedFloat;
    bool boolValue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CubeRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speedFloat*Time.deltaTime, 0, 0);
    }
    IEnumerator CubeRoutine()
    {
      for(int i = 0; i < 5; i++)
        {
            Debug.Log("Step 1");
            speedFloat = 1f;
            yield return new WaitForSeconds(2);
            print("Step 2");
            speedFloat = 0f;
            yield return new WaitForSeconds(1);
            print("Step 3");
            speedFloat = -1f;
            yield return new WaitForSeconds(2);
            print("Step 4");
            speedFloat = 0f;
            yield return new WaitForSeconds(1);
        }
        print("Step 5");
        yield break;
    }
}