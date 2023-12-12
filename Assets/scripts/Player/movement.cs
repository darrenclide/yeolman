using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;
    public float publicFloat;
    float horizontalInput;
    float verticalInput;

    public Slider slider;
    public void SetStamina(float stamina)
    {
        slider.value = stamina;
    }
    public Animator animator;
    Vector3 moveDirection;
    Rigidbody rb;
    public float stamina;
    public float staminaRegen;
    public AudioSource footstepsSound;
    // Start is called before the first frame update
    void Start()
    {
        staminaRegen = 15f;
        stamina = 100;
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
        SetStamina(stamina);
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w") == true && stamina > 0)
        {
            stamina -= staminaRegen * Time.deltaTime;
            publicFloat = 15f;
            animator.SetBool("run", true);
        }
        else
        {
            if(stamina < 101)
            {
                stamina += staminaRegen * Time.deltaTime;
            }
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
            footstepsSound.enabled = true;
            animator.SetBool("walk", true);
        }
        else
        {
            footstepsSound.enabled = false;
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
