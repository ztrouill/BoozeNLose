using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float        speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = .5f;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
            transform.Translate(speed * x, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Translate(speed * x, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
            transform.Translate(0, 0, speed * z);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            transform.Translate(0, 0, speed * z);
        if (Input.GetKey(KeyCode.Space))
            if (transform.position.y < -43)
                GetComponent<Rigidbody>().AddForce(0, 100, 0);
            else return;
    }
}
