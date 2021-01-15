using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource AudioData;
    void Start()
    {
        AudioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void ReproducirSonido()
    {
        AudioData.Play();
    }
}
