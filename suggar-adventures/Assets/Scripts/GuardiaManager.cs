using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaManager : MonoBehaviour
{
    
    
    //la variable visionRadius almacena el radio de vision que tendrá el guardia. la variable speed es la el multiplicador de la velocidad de movimiento
    public float visionRadius;
    public float visionAttackRange;
    public float speed;
    public CharacterController2D controller;
    float horizontalMovement;

    private Animator animator;
    //player es la variable para guardar al jugador.
    GameObject player;
    //variable para guardar la posición inicial
    Vector3 initialPosition;
    void Start()
    {
        //Se busca al jugador con el Tag(se cambia el tag dentro de unity)
        player = GameObject.FindWithTag("Player");
        //Guardamos nuestra posición inicia
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        
        //el Guardia siempre tendrá como posición inicial el primer punto
        Vector3 target = initialPosition;
        
        //en el caso de que player ingrese al radio, la posición inicial pasará a ser la ubicación del player
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius)
        {
            
            target = player.transform.position;
            
            animator.SetBool("isInRange",true);
            if (dist < visionAttackRange)
            {
                animator.SetBool("isInAttackRange",true);
            }
            else
            {
                animator.SetBool("isInAttackRange",false);
            }
        }
        else
        {
            animator.SetBool("isInRange",false);
        }

        
        
        
        //esto mueve al guardia a la posición del player
        float fixedSpeed = speed * Time.deltaTime;
        Vector3 actualPosition = transform.position;
        float axis = target.x - actualPosition.x;
        //dejar el axis entre 1 y -1
        horizontalMovement = -axis * fixedSpeed;
        Debug.Log(actualPosition);

        
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        
        //esto dibuja la línea que seguirá el guardia para llegar hasta el player (sólo será visible en la escena)
        Debug.DrawLine(transform.position,target,Color.red);
        if( actualPosition.x != initialPosition.x)
        {
            animator.SetBool("isAtInitialPosition", false);
        }
        else
        {
            animator.SetBool("isAtInitialPosition", true);

        }
    }

    private void OnDrawGizmos()
    {   
        //esta función dibuja el radio visión del guardia (Sólo lo dibuja en la escena)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,visionRadius);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position,visionAttackRange);
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, false);
        
    }
}
