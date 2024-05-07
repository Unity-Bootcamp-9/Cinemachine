using UnityEngine;

public class BoxActivator : MonoBehaviour
{
    public GameObject virtualCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            virtualCamera.SetActive(true);
            Invoke("CameraOff", 3f);

        }
    }

    private void CameraOff()
    {
        virtualCamera.SetActive(false);
    }
}
