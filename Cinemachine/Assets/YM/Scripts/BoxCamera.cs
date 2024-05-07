using UnityEngine;
using Cinemachine;

public class BoxActivator : MonoBehaviour
{
    public CinemachineVirtualCamera BoxCamera;
    public CinemachineVirtualCamera BossCamera;

    private void Start()
    {
        Invoke("BossCameraOn", 20f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            BoxCamera.m_Priority = 15;
            Invoke("BoxCameraOff", 3f);
        }
    }

    private void BoxCameraOff()
    {
        BoxCamera.m_Priority = 5;
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
