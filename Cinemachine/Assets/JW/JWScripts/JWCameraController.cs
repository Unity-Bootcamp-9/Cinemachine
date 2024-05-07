using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWCameraController : MonoBehaviour
{
    public CinemachineVirtualCamera baseCam;
    public CinemachineVirtualCamera targetCam;

    public void CameraChange(CinemachineVirtualCamera baseCam, CinemachineVirtualCamera changeCamera)
    {
        baseCam.Priority = 0;   
        changeCamera.Priority = 10;
    }
}
