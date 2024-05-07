using Cinemachine;
using UnityEngine;

public class BoxActivator : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            virtualCamera.m_Priority = 15;
            Invoke("CameraOff", 3f);

        }
    }

    private void CameraOff()
    {
        virtualCamera.m_Priority = 5;
    }
}
