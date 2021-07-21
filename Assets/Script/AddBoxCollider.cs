using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoxCollider : MonoBehaviour
{
    private GameObject[] buildingPrefab;

    // Start is called before the first frame update 
    void Start()
    {
        buildingPrefab = GameObject.FindGameObjectsWithTag("Building");

        foreach (GameObject building in buildingPrefab)
        {
            GameObject children = building.transform.GetChild(0).gameObject;
            children.AddComponent<BoxCollider>();
        }           
    }
}
