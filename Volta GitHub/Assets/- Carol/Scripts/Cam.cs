using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public static bool isFps = true;
    public Transform player;
    public GameObject fpsCamera, tpsCamera;
    // Start is called before the first frame update
    void Start()
    {
        ChangeCamera(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        player.localEulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (Input.GetButtonDown("Fire3"))
        {
            ChangeCamera(!isFps);
        }
    }
    void ChangeCamera(bool value)
    {
        isFps = value;
        if (isFps)
        {
            fpsCamera.SetActive(true);
            tpsCamera.SetActive(false);
        }
        else
        {
            fpsCamera.SetActive(false);
            tpsCamera.SetActive(true);
        }
    }
}
