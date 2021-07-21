using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -50)
            Destroy(transform.gameObject); // Destruction objets mals placés qui tombent car la map n'est pas rectangulaire
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
            Destroy(transform.gameObject);
    }
}
