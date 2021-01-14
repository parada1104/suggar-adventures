using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuggarFollow : MonoBehaviour
{
    public GameObject daddy;
/*
    public Transform Player;
    private Vector3 vel = Vector3.zero;
    public float Tiemsua = .15f;
    */
    
 /*   public Vector2 minimo;
    public Vector2 maximo;
    public float suavizado;
    Vector2 velocity;
    */
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    //Con esta función vamos a hacer que la camara siga a daddy pero que lo limite a ciertos rangos
    void Update()
    {
        /*
        Vector3 Pospla = Player.position;
        Pospla.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, Pospla, ref vel, Tiemsua);
*/
        /*
        float posX = Mathf.SmoothDamp(transform.position.x, daddy.transform.position.x, ref velocity.x , suavizado);
        float posY = Mathf.SmoothDamp(transform.position.y, daddy.transform.position.y, ref velocity.y, suavizado);

        transform.position = new Vector3(Mathf.Clamp(posX,minimo.x,maximo.x),Mathf.Clamp(posY,minimo.y,maximo.y), transform.position.z) ;
        */
    }
}
