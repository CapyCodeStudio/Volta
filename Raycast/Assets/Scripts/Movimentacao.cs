using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public float mouseSesivity = 100f;
    public Transform playerBody;

    float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSesivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSesivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
