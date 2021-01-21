using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void Jugar()
    {
        SceneManager.LoadScene("Cataratas del iwasu");

    }
    public void Salir()
    {
        Application.Quit();
    }
}
