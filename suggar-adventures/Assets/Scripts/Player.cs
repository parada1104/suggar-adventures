using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.iOS;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{   
    //esta variable almacena el multiplicador de velocidad que tendrá el player
    public float speed;
    //almacenamos el punto de destino
    Vector3 target;
    void Start()
    {   
        //establecemos la posición inicial como punto de destino
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Detecta cuando se pulsa el click izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            //Se busca la posición del click dentro de la escena
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //establecemos z como 0 para que no modifique la profundidad
            target.z = 0f;
        }
        
        //el player se mueve hacía donde hemos clickeado con la velocidad ya establecida
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        //se dibuja la lína que sigue el player(sólo será visible en scene)
        Debug.DrawLine(transform.position, target, Color.green);
    }
}
