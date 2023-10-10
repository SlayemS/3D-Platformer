using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float walkSpeed = 6;
    private float runSpeed = 10;
    // public Rigidbody rb;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public Animator an;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire3")) 
        {
            moveSpeed = runSpeed;
        }
        else {
            moveSpeed = walkSpeed;
        }
        
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        
        if (controller.isGrounded) {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump")) {
                moveDirection.y = jumpForce;
                // if (Input.GetButtonDown("Jump") && Instance.powerUp == true) {
                //     moveDirection.y = jumpForce;
                // }
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        an.SetBool("isGrounded", controller.isGrounded);
        an.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    }
}
