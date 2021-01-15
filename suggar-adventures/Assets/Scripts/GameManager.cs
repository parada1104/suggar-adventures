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
    public Text BilletestText;
    public Image vida;
    //Se establece 100 como vida inicial
    private float hp, maxHP = 100f;

    // Start is called before the first frame update

    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

        //la vida inicial comienza siendo la vida máxima
        hp = maxHP;
        BillCount =  BillCount > 0 ? BillCount : 0; //if player has gotten bills before gather it
        InitialBillCount = BillCount;
    }

    // Update is called once per frame
    void Update()
    {
        BilletestText.text = BillCount.ToString();
        //En esta parte la funcion parte del fondo de nuestra escena haga la ilusion de mover el fondo
        if (gameState == GameState.Ended)
        {
            ReiniciarJuego();
        }
    }

    public void ReiniciarJuego()
    {
        Scene escena = SceneManager.GetActiveScene();
        Destroy(gameObject);
        SceneManager.LoadScene(escena.name);
        BillCount = InitialBillCount;
    }

        public void TomarDaño(float cant)
    {
        //Se encarga de que la vida no puede ser menor que 0 ni mayor que 100
        hp = Mathf.Clamp(hp - cant, 0f, maxHP);
        //cambia la escala del sprite para simular una barra que disminuye
        vida.transform.localScale = new Vector2(hp / maxHP, 1);
        if (hp == 0f)
        {
            this.SendMessage("ReiniciarJuego");
        }
        
    }
}


