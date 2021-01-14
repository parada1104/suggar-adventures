using System.Collections;
using System.Collections.Generic;using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum GameState{Idle, Playing, Ended};

public class GameManager : MonoBehaviour
{
    private GameState gameState = GameState.Idle;
   
    //El renderer hace alusión para poder realizar un update del fondo para que haga la ilusión indirectamente de mover el mapa
    public Renderer fondo;

    public int ScorePoints; //it will be decided by a personalized algorith based on life and bills get on a level
    public int BillCount; //just tell how many bills player has gotten
    public int InitialBillCount; //Quantity of Bills gotten before the level

    // Start is called before the first frame update
    void Start()
    {
      BillCount =  BillCount > 0 ? BillCount : 0; //if player has gotten bills before gather it
      InitialBillCount = BillCount;
    }

    // Update is called once per frame
    void Update()
    {
        //En esta parte la funcion parte del fondo de nuestra escena haga la ilusion de mover el fondo
        if (gameState == GameState.Ended)
        {
            ReiniciarJuego();
        }
    }

    public void ReiniciarJuego()
    {
        Scene escena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escena.name);
        BillCount = InitialBillCount;
    }
}


