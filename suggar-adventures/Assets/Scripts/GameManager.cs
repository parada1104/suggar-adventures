using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Piso1;
    public Renderer fondo;

    // Start is called before the first frame update
    void Start()
    {
        // Mapa Infinito
        for (int i=0 ; i<21 ; i++){
            Instantiate(Piso1, new Vector2(-10 + i,-4.5f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.010f,0) * Time.deltaTime;
    }
}
