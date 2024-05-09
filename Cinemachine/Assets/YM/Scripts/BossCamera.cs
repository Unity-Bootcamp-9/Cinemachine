using UnityEngine;
using Cinemachine;

public class DragonController : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;
    public GameObject Dragon;

    private void OnEnable()
    {
        if (Dragon != null)
        {
            InvokeRepeating("GenerateImpulse", 0f, 1f);
        }
    }

    // ����� �߻���Ű�� �޼���
    private void GenerateImpulse()
    {
        impulseSource.GenerateImpulse();
    }

}