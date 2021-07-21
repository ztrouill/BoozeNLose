using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGeneration : MonoBehaviour
{
    public Transform bottlesObj;
    private Transform[][] bottles;
    private GameObject[] groundPrefab;
    private GameObject groundParent;
    private GameObject cloneBottles;
    private int s = 0;
    private int a = 0;
    Vector2 min;


    // Start is called before the first frame update
    void Start()
    {

        CreateArrayBottles();
        FillArray();
        CreateGroundObject();
        CreateAllBottles();
    }

    private void CreateArrayBottles()
    {
        bottles = new Transform[2][];

        foreach (Transform bottle in bottlesObj)
        {
            if (bottle.transform.CompareTag("Alcohol") || bottle.transform.CompareTag("Soft"))
            {
                if (bottle.transform.CompareTag("Alcohol"))
                    a++;
                if (bottle.transform.CompareTag("Soft"))
                    s++;
            }
        }

        bottles[0] = new Transform[a];
        bottles[1] = new Transform[s];

        cloneBottles = new GameObject();
        cloneBottles.name = "Clone Bottles";
    }

    private void FillArray()
    {
        s = 0;
        a = 0;

        foreach (Transform bottle in bottlesObj)
        {
            if (bottle.transform.CompareTag("Alcohol") || bottle.transform.CompareTag("Soft"))
            {

                if (bottle.transform.CompareTag("Alcohol"))
                {
                    bottles[0][a] = bottle.transform;
                    a++;
                }
                if (bottle.transform.CompareTag("Soft"))
                {
                    bottles[1][s] = bottle.transform;
                    s++;
                }

                bottle.gameObject.AddComponent<SpriteRotation>();
                bottle.gameObject.AddComponent<CheckPosition>();
            }
        }
    }

    private void CreateAllBottles()
    {
        InstanciateBottles(bottles[0], 60); // Alcool
        InstanciateBottles(bottles[1], 20); // Soft
    }

    private void CreateGroundObject() // Rassemble tous les objets de sols et calcule leur position mini (la maxi est connue) pour placer aléatoirement les objets
    {
        groundPrefab = GameObject.FindGameObjectsWithTag("Ground");
        groundParent = new GameObject();
        groundParent.name = "groudObj";

        min = new Vector2(0, 0);

        foreach (GameObject ground in groundPrefab)
        {
            ground.transform.parent = groundParent.transform;

            if (min.x > ground.transform.position.x)
                min.x = ground.transform.position.x;
            if (min.y > ground.transform.position.z)
                min.y = ground.transform.position.z;
        }
    }

    private void InstanciateBottles(Transform[] bottles, int nb)
    {
        int clone = 0;
        int j;

        for (int i = 0; i < nb; i++)
        {
            if (bottles.Length == 2)
            {
                j = Random.Range(0, 16);
                j = j % 2 == 0 ? 0 : 1;
            }
            else j = Random.Range(0, bottles.Length - 1);
         

            float posX = Random.Range((min.x + 20), -20);

            Transform newClone;
            newClone = Instantiate(bottles[j]);
            float posZ = Random.Range(-199, -20);
            newClone.position = new Vector3(posX, transform.position.y, posZ);
            newClone.transform.parent = cloneBottles.transform;
            clone++;
        }
    }

    public void ResetBottles()
    {
        foreach (Transform clone in cloneBottles.transform)
            Destroy(clone.gameObject);
        CreateAllBottles();
    }
}
