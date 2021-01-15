using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float SpeedMov;
    public float posMax;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;
*/
        if (transform.position.x < posMax)
        {
            transform.position += (new Vector3 (SpeedMov,0 ,0)) * Time.deltaTime;
        }

        
    
    }
}
