using UnityEngine;
using Cinemachine;

public class BoxActivator : MonoBehaviour
{
    public CinemachineVirtualCamera MapCamera;
    public CinemachineVirtualCamera BoxCamera1;
    public CinemachineVirtualCamera BoxCamera2;
    public CinemachineVirtualCamera BossCamera;
    public GameObject Dragon;

    private void Start()
    {
        Invoke("MapCameraOff", 8f);
        Invoke("BossCameraOn", 30f);
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

    private void MapCameraOff()
    {
        MapCamera.m_Priority = 5;
    }

    private void BossCameraOn()
    {
        Dragon.SetActive(true);
        BossCamera.m_Priority = 15;
        Invoke("BossCameraOff", 5f);
    }
    private void BossCameraOff()
    {
        BossCamera.m_Priority = 5;
    }
    
}
