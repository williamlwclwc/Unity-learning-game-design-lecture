using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour {

    private static audiomanager _instance;
    
    public static audiomanager Instance
    {
        get
        {
            return _instance;
        }
    }

    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    public AudioSource efxSource;
    public AudioSource bgm;

    void Awake()
    {
        _instance = this; 
    }
    public void RandomPlay(params AudioClip[] clips)
    {
        float pitch = Random.Range(minPitch, maxPitch);
        int index = Random.Range(0, clips.Length);
        AudioClip clip = clips[index];
        efxSource.clip = clips[index];
        efxSource.pitch = pitch;
        efxSource.Play();
    }
    public void stopbgm()
    {
        bgm.Stop();
    }
}
