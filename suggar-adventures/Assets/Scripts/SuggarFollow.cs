using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuggarFollow : MonoBehaviour
{
    public GameObject follow;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;

        transform.position = new Vector3( transform.position.x, posY+4, transform.position.z);
    }
}
