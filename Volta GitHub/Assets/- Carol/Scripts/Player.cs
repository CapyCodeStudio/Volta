using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera thirdPersonCam;
    [SerializeField] CinemachineVirtualCamera firstPersonCam;
    public FPMovement firstPersonCamera;
    public Movement thirdPersonCamera;

    private void OnEnable()
    {
        CameraSwitcher.Register(thirdPersonCam);
        CameraSwitcher.Register(firstPersonCam);
        CameraSwitcher.SwitchCamera(thirdPersonCam);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(thirdPersonCam);
        CameraSwitcher.Unregister(firstPersonCam);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CameraSwitcher.IsActiveCamera(thirdPersonCam))
            {
                CameraSwitcher.qualCamera = "primeira";
                CameraSwitcher.SwitchCamera(firstPersonCam);
            }
            else if (CameraSwitcher.IsActiveCamera(firstPersonCam))
            {
                CameraSwitcher.qualCamera = "terceira";
                CameraSwitcher.SwitchCamera(thirdPersonCam);
            }

            if (CameraSwitcher.qualCamera == "primeira")
            {
                firstPersonCam.enabled = true;
                thirdPersonCam.enabled = false;
            }

            else if (CameraSwitcher.qualCamera == "terceira")
            {
                    firstPersonCam.enabled = false;
                     thirdPersonCam.enabled = true;
            }
        }
    }
}

