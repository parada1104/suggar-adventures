using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaddyManager : MonoBehaviour
{
    public CharacterController2D controller;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    float horizontalMovement = 0f;
    bool jump = false;
    

    //parameters
    public float runSpeed = 40f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //prueba git discord
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        Debug.Log(horizontalMovement);
        if (horizontalMovement > 0 || horizontalMovement < 0)
        {
            animator.SetBool("IsInMove",true);
        }
        else
        {
            animator.SetBool("IsInMove",false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsInAir",true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsInAir",false);
    }

    //for movement
    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }
}
