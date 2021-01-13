using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    //El renderer hace alusión para poder realizar un update del fondo para que haga la ilusión indirectamente de mover el mapa
    public Renderer fondo;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //En esta parte la funcion parte del fondo de nuestra escena haga la ilusion de mover el fondo

        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.005f, 0) * Time.deltaTime;

    }
}
