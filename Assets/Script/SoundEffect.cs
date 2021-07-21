using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    AudioSource[] sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponents<AudioSource>();
    }

    public void PlaySound(int type)
    {
        sound[type].Play();
    }
}
