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

    // 충격을 발생시키는 메서드
    private void GenerateImpulse()
    {
        impulseSource.GenerateImpulse();
    }

}