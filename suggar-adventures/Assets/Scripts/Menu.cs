using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string ScenaPrincipal;
   public void Jugar()
    {
        SceneManager.LoadScene(ScenaPrincipal);
        PlayerPrefs.SetString("EscenaPrincipal",ScenaPrincipal);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
