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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    //for movement
    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
