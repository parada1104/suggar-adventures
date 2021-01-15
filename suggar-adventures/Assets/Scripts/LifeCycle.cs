using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0,1)][SerializeField]
    private float LifeTime;
    void Start()
    {
        Destroy(gameObject,LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
