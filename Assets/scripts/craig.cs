using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class craig : MonoBehaviour
{
    public GameObject player;
    public Transform playerPosition;
    public NavMeshAgent agent;
    float distance;
    public LayerMask playerLayerMask;
    RaycastHit hit;
    public float range; //radius of sphere
    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.x - transform.position.x;
        
            if (distance < 12.5 && distance > -12.5)
            {
                print("Craig_NPC: Chasing player.");
                Debug.DrawRay(playerPosition.position, Vector3.up, UnityEngine.Color.red, 1.0f); //so you can see with gizmos
                agent.SetDestination(playerPosition.position);
            }
            else if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
                {
                    print("Craig_NPC: Wandering.");
                    Debug.DrawRay(point, Vector3.up, UnityEngine.Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                }
            }
    }
    bool IsObjectVisible(Transform playerPosition)
    {
        // Calculate the direction from the camera to the target
        Vector3 direction = playerPosition.position - Camera.main.transform.position;

        // Perform a raycast to check for obstacles between the camera and the target
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, direction, out hit))
        {
            // Check if the hit object is the target
            if (hit.transform == playerPosition)
            {
                // The target is visible
                return true;
            }
        }

        // The target is not visible
        return false;
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
