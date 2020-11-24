using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioM : MonoBehaviour
{

    public AudioSource som;
    public static AudioM inst = null;

    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
        else if(inst != this)
        {
            Destroy(gameObject);
        }
            
    }
    public void PlayAudio(AudioClip clipaudio)
    {
        som.clip = clipaudio;
        som.Play();
    }
}
