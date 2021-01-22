using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float SpeedMov;
    [Range(130,200)][SerializeField] float posMax;
    [SerializeField]
    private string NextScene;
    private GameObject Player;
    private GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        Player = GameObject.Find("Daddy 1");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;
*/

        if (transform.position.x > posMax)
        {
          SceneManager.LoadScene(NextScene);
        }


        transform.position += (new Vector3 (SpeedMov,0 ,0)) * Time.deltaTime;
        float PlayerX =  Player.transform.position.x;
        float Distancia = PlayerX - transform.position.x;
        if(Distancia < - 13)
        {
          gameManager.SendMessage("ReiniciarJuego");
        }
    }
}
