using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour
{
    float speedFloat;
    bool boolValue;
    public float randomTime;
    public float rotationValue;
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TankRoutine());
        print(rotationValue);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = newRotation = new Vector3(0, rotationValue * Time.deltaTime, 0);
        transform.eulerAngles += newRotation;
        transform.position += transform.forward * Time.deltaTime *vel;
    }
    IEnumerator TankRoutine()
    {
        for (int i = 0; i < 5; i++)
        {
            randomTime = Random.Range(0.5f, 1f);
            rotationValue = Random.Range(15f, 360f);
            print(randomTime);
            yield return new WaitForSeconds(randomTime);
            rotationValue = 0;
            yield return new WaitForSeconds(1);
            randomTime = Random.Range(0.5f, 3f);
            print(randomTime);
            vel = 5f;
            yield return new WaitForSeconds(1);
            vel = 0f;
            yield return new WaitForSeconds(1);
        }
        yield break;
    }
}
