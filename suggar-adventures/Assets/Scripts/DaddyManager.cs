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
    private float horizontalMovement = 0f;
    bool jump;
    float jumpPower = 3.1f;
    private bool movimiento = true;
    private SpriteRenderer spr;
    private GameManager gameManager;
    private SoundManager SonidoSalto;
    private SoundManager SonidoPaso;
    

    //parameters
    public float runSpeed = 40f;


    // Start is called before the first frame update
    void Start()
    {
        SonidoPaso = GetComponentInChildren<SoundManager>();
        SonidoSalto = GetComponentInChildren<SoundManager>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (horizontalMovement > 0 || horizontalMovement < 0)
        {
          RealizarPasos();
        }
        else
        {
            animator.SetBool("IsInMove",false);
        }

        if (Input.GetButtonDown("Jump"))
        {
          if(animator.GetBool("IsInAir") == false)
          {
            RealizarSalto();
          }
        }
        //para reiniciar el juego
        if( transform.position.y < -8)
        {
          gameManager.ReiniciarJuego();
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
        if (!movimiento)horizontalMovement = 0;
        jump = false;
        if (jump)
        {
            rigidbody2D.AddForce(Vector2.up*jumpPower,ForceMode2D.Impulse);
        }
    }
    //Función de KnockBack al recibir daño, además del cambio en la barra de vida
    public void enemyKnockBack(float enemyPosX)
    {
        //Se resta la vida al recibir daño
        gameManager.SendMessage("TomarDaño",15);
        //Realiza el salto emulando el "impacto del golpe", además su tonalidad cambia a roja por .4 segundos
        jump = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rigidbody2D.AddForce(Vector2.left*side*jumpPower,ForceMode2D.Impulse);
        movimiento = false;
        Invoke("ActivarMovimiento", 0.4f);
        spr.color = Color.red;
    }
    void ActivarMovimiento()
    {
        movimiento = true;
        spr.color = Color.white;
    }
    void OnTriggerEnter2D(Collider2D Objeto) {
        //if collide with bills, destroy this bill
        if(Objeto.tag == "Bill")
        {
            gameManager.BillCount += 1;
            Destroy(Objeto.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "pikes")
        {
            gameManager.SendMessage("TomarDaño",15);
            Invoke("ActivarMovimiento",0.4f);
            spr.color = Color.red;
        }
    }

    private void RealizarSalto()
    {
        jump = true;
        animator.SetBool("IsInAir",true);
    }

    private void RealizarPasos()
    {
        animator.SetBool("IsInMove",true);
        if(animator.GetBool("IsInAir") == true)
        {
          animator.SetBool("IsInAir", false);
        }
    }

    private void ReproducirPaso()
    {
        SonidoPaso.ReproducirSonido();
    }
    private void ReproducirSalto()
    {
        SonidoSalto.ReproducirSonido();
    }
}
