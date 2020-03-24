using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    public AudioClip[] BGM;
    AudioSource audiosource;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
       int random = UnityEngine.Random.Range(0,3);
        audiosource.clip = BGM[random];
        audiosource.Play();
        audiosource.loop = true;
    }

}
