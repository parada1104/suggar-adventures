using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool active;

    Canvas Pausa;
    // Start is called before the first frame update
    void Start()
    {
        Pausa = GetComponent<Canvas>();
        Pausa.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            active = !active;
            Pausa.enabled = active;
            Time.timeScale = (active) ? 0: 1f;
        }
    }
}
