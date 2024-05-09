using UnityEngine;
using Cinemachine;

public class BoxActivator : MonoBehaviour
{
    public CinemachineVirtualCamera BoxCamera1;
    public CinemachineVirtualCamera BoxCamera2;
    public CinemachineVirtualCamera BossCamera;

    private void Start()
    {
        Invoke("BossCameraOn", 20f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box1"))
        {
            BoxCamera1.m_Priority = 15;
            Invoke("BoxCameraOff", 5f);
        }
        if (other.CompareTag("Box2"))
        {
            BoxCamera2.m_Priority = 15;
            Invoke("BoxCameraOff2", 5f);
        }
    }

    private void BoxCameraOff()
    {
        BoxCamera1.m_Priority = 5;
    }

    private void BoxCameraOff2()
    {
        BoxCamera2.m_Priority = 5;
    }


    private void BossCameraOn()
    {
        BossCamera.m_Priority = 15;
        Invoke("BossCameraOff", 5f);
    }
    private void BossCameraOff()
    {
        BossCamera.m_Priority = 5;
    }
    
}
