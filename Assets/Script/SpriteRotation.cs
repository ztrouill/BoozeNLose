using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    private Transform[] sprites;
    private MouseLook mouseLook;

    // Start is called before the first frame update
    void Start()
    {
        mouseLook = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        sprites = new Transform[transform.childCount];

        for (var i = 0; i < transform.childCount; i++)
            sprites[i] = transform.GetChild(i);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(90, mouseLook.GetY(), 180);
    }
}