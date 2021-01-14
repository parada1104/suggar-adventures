using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaCaja : MonoBehaviour
{
    public float fallDelay;

    private Rigidbody2D rb2d;
    private PolygonCollider2D pc2d;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("Fall" , fallDelay);
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;
        pc2d.isTrigger = true;
    }
}
