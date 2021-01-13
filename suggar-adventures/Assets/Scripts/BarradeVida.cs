using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarradeVida : MonoBehaviour
{
    //se importa el sprite de vida
    public Image vida;
    //Se establece 100 como vida inicial
    private float hp, maxHP = 100f;
    void Start()
    {
        //la vida inicial comienza siendo la vida máxima
        hp = maxHP;
    }

    public void TomarDaño(float cant)
    {
        //Se encarga de que la vida no puede ser menor que 0 ni mayor que 100
        hp = Mathf.Clamp(hp - cant, 0f, maxHP);
        //cambia la escala del sprite para simular una barra que disminuye
        vida.transform.localScale = new Vector2(hp / maxHP, 1);
        
    }
}
