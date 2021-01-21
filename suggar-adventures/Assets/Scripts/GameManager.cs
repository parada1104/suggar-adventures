using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum GameState
{
  Idle,
  Playing,
  Ended
};

public class GameManager : MonoBehaviour
{
    private GameState gameState = GameState.Idle;
    public int ScorePoints; //it will be decided by a personalized algorith based on life and bills get on a level
    public int BillCount; //just tell how many bills player has gotten
    public int InitialBillCount; //Quantity of Bills gotten before the level
    public Text BilletestText;
    public Image vida;
    private float hp, maxHP = 100f; //Se establece 100 como vida inicial y maxima
    private string BillsPrefsName = "Billcount";
    private string ScorePointsPrefName = "ScorePoints";
    private Scene ActualScene;
    private float CompletitionTime;

    // Start is called before the first frame update
    private void Awake() 
    {
        if(ActualScene.name != "Seatle")
        {
          LoadData();
        }
    }
    void Start()
    {
        ActualScene = SceneManager.GetActiveScene();
        hp = maxHP; //la vida inicial comienza siendo la vida máxima
        BillCount = ActualScene.name == "Seatle" ? 0 : BillCount; //if player has gotten bills before gather it
        ScorePoints = 0;
        CompletitionTime = 0;
        InitialBillCount = BillCount;
    }

    // Update is called once per frame
    void Update()
    {
        BilletestText.text = BillCount.ToString();
        if (gameState == GameState.Ended)//En esta parte la funcion parte del fondo de nuestra escena haga la ilusion de mover el fondo
        {
            ReiniciarJuego();
        }
        CompletitionTime += 1 * Time.deltaTime;
        Debug.Log(CompletitionTime);
    }

    public void ReiniciarJuego()
    {
        Scene escena = SceneManager.GetActiveScene();
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

    private void OnDestroy() {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(BillsPrefsName,BillCount);
        PlayerPrefs.SetInt(ScorePointsPrefName, ScorePoints);
    }

    private void LoadData()
    {
        BillCount = PlayerPrefs.GetInt(BillsPrefsName, 0);
        ScorePoints = PlayerPrefs.GetInt(ScorePointsPrefName, 0);
    }

    float CalculoPuntaje(float time, int BillCount, float hp)
    {
      int puntaje = (int)((BillCount/time)*hp);
      return puntaje;
    }
}


