using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    public Animator animator;
    Vector3 moveDirection;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
          
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("f") == true)
        {
            animator.SetBool("light", true);
        }
        else 
        {
            animator.SetBool("light", false);
        }
        if (Input.GetKey("w") == true || Input.GetKey("s") == true || Input.GetKey("a") == true || Input.GetKey("d") == true)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        MyInput();
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
}
