using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCameraMove : MonoBehaviour
{
    CinemachineVirtualCameraBase cam;

    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCameraBase>();
    }
    void Update()
    {
        if (cam.Priority != 0 && cam.transform.position.y > 5)
        {
            Vector3 camMove = new Vector3(0, -1, 0);
            transform.position += camMove * Time.deltaTime * 5;
        }
    }
}
