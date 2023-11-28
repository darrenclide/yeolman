using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;
    public float publicFloat;
    float horizontalInput;
    float verticalInput;
    public Animator animator;
    Vector3 moveDirection;
    Rigidbody rb;
    public AudioSource startSound;
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
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w") || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.RightShift) && Input.GetKey("w") || Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.UpArrow) == true)
        {
            publicFloat = 15f;
            animator.SetBool("run", true);
        }
        else
        {
            publicFloat = 10f;
            animator.SetBool("run", false);
        }
        if(Input.GetKey("f") == true || Input.GetKey(KeyCode.Keypad4) == true)
        {
            animator.SetBool("light", true);
        }
        else 
        {
            animator.SetBool("light", false);
        }
        if (Input.GetKey("w") || Input.GetKey("s")|| Input.GetKey("a")|| Input.GetKey("d") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) == true)
        {
            startSound.enabled = true;
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
        rb.AddForce(moveDirection.normalized * moveSpeed * publicFloat, ForceMode.Force);
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
}
