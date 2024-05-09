using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JWCameraController : MonoBehaviour
{
    public CinemachineVirtualCameraBase currentCam;
    
    public CinemachineVirtualCameraBase baseCam;
    public CinemachineVirtualCameraBase zoomCam;
    public CinemachineVirtualCameraBase lockOnCam;
    public CinemachineVirtualCameraBase bossCamera;


    public List<CinemachineVirtualCameraBase> cameras = new List<CinemachineVirtualCameraBase>();

    private void Start()
    {
        currentCam = baseCam;

        cameras.Add(baseCam);
        cameras.Add(zoomCam);
        cameras.Add(bossCamera);

        foreach (var cam in cameras)
        {
            cam.Priority = 0;
        }
        
        currentCam.Priority = 10;
    }

    public void SetCamera(CinemachineVirtualCameraBase camera)
    {
        currentCam = camera;

        foreach(var cam in cameras)
        {
            cam.Priority = 0;
        }

        currentCam.Priority = 10;
    }
}
