using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float velocidad=2;
    public GameObject Piso1;
    public GameObject Piso2;
    public Renderer fondo;
    
    public List<GameObject> Pisos;
    // Start is called before the first frame update
    void Start()
    {
        // Mapa Infinito
        for (int i=0 ; i<21 ; i++){
            //Pisos.Add(Instantiate(Piso1, new Vector2(-10 + i,-4.5f), Quaternion.identity));
            Instantiate(Piso1, new Vector2(-10 + i,-4.5f), Quaternion.identity);
        }
/*
        for (int j=21 ; j<40 ; j++){
            Pisos.Add(Instantiate(Piso2, new Vector2(-10 + j , -4) , Quaternion.identity));
        }
 */ 
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.005f,0) * Time.deltaTime;

         // Mover Mapa
        /*for (int i =0 ;i<Pisos.Count ; i++){
            Pisos[i].transform.position = Pisos[i].transform.position + new Vector3(-1,0,0)*Time.deltaTime * velocidad;
        }
        */
    }
}
