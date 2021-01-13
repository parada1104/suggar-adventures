using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class DaddyManager : MonoBehaviour
{
    public CharacterController2D controller;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    float horizontalMovement = 0f;
    bool jump;
    float jumpPower = 6.5f;
    private bool movimiento = true;
    private SpriteRenderer spr;
    private GameObject BarradeVida;
    

    //parameters
    public float runSpeed = 40f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        BarradeVida = GameObject.Find("BarradeVida");
    }

    // Update is called once per frame
    void Update()
    {
        //prueba git discord
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        
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
        if (!movimiento) horizontalMovement = 0;
        jump = false;
        if (jump)
        {
            rigidbody2D.AddForce(Vector2.up*jumpPower,ForceMode2D.Impulse);
            jump = false;
        }
        
    }
    public void enemyKnockBack(float enemyPosX)
    {
        BarradeVida.SendMessage("TomarDaño",15);
        jump = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rigidbody2D.AddForce(Vector2.left*side*jumpPower,ForceMode2D.Impulse);
        movimiento = false;
        Invoke("ActivarMovimiento",0.4f);
        spr.color = Color.red;
    }

    void ActivarMovimiento()
    {
        movimiento = true;
        spr.color = Color.white;
    }
}
