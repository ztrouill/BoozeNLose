 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=_QajrabyTJc&t=1113s // Utilisation d'une partie du tuto

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 80f;

    public Transform playerBody;
    public GetDrunk getDrunk;

    float xRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        getDrunk = GetComponent<GetDrunk>();   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, getDrunk.GetCamZ());

        playerBody.Rotate(Vector3.up * mouseX);
    }

    public float GetX()
    {
        return xRotation;
    }

    public float GetY()
    {
        return playerBody.transform.eulerAngles[1];
    }
}
