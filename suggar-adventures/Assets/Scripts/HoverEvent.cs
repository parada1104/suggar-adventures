using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEvent : MonoBehaviour
{
    AudioSource AudioData;
    void Start()
    {
        AudioData = GetComponent<AudioSource>();
    }

    public void OnMouseOver()
    {
        AudioData.Play(0);
    }

    void OnMouseExit()
    {

    }
}

