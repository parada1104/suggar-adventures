using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Tenemos el Game Object para hacer relacion hacia el piso y poder instanciarlo con el escenario
    //El renderer hace alusión para poder realizar un update del fondo para que haga la ilusión indirectamente de moverl el mapa
    //por parte de la velocidad, define la rapidez en la que se mueve el piso
    // por parte de la lista de objetos podemos hacer el mapa infinito

    public float velocidad=2;
    public GameObject Piso1;
    public GameObject Piso2;
    public GameObject fuego;
    public Renderer fondo;
    
    public List<GameObject> Pisos;
    // Start is called before the first frame update
    void Start()
    {
        // Mapa Infinito
        
        //Por esta parte lo que se realiza es con el for instanciar al piso para que aparezca en ciertas posicion en x
        for (int i=0 ; i<21 ; i++){
            //Pisos.Add(Instantiate(Piso1, new Vector2(-10 + i,-4.5f), Quaternion.identity));
            Instantiate(Piso1, new Vector2(-10 + i,-4.5f), Quaternion.identity);
        }

        for (float l = 21.9f; l < 25.8f; l++)
        {
            Instantiate(fuego, new Vector2( -10+ l, -4.8f), Quaternion.identity);
        }
        for (int j=27 ; j<50 ; j++){
            //Pisos.Add(Instantiate(Piso2, new Vector2(-10 + j , -4) , Quaternion.identity));
            Instantiate(Piso2, new Vector2(-10 + j, -4.5f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //En esta parte la funcion parte del fondo de nuestra escena haga la ilusion de mover el fondo
        
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.005f,0) * Time.deltaTime;

         // Mover Mapa
        /*for (int i =0 ;i<Pisos.Count ; i++){
            Pisos[i].transform.position = Pisos[i].transform.position + new Vector3(-1,0,0)*Time.deltaTime * velocidad;
        }
        */
    }
}
