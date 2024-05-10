using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour
{
    [SerializeField] private CinemachineImpulseSource _source;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _source.GenerateImpulse();


        }
    }

}
