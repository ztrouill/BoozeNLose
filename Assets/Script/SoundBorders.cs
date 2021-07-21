using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBorders : MonoBehaviour
{
    GameObject[] clouds;

    // Start is called before the first frame update
    void Start()
    {
        clouds = GameObject.FindGameObjectsWithTag("CloudsToy");
        for (int i = 0; i < clouds.Length; i++)
            clouds[i].AddComponent<SoundEffect>();
    }
}
