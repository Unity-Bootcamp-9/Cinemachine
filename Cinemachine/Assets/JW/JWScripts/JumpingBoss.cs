using System.Collections;
using System.Collections.Generic;
using Unity.Sentis.Layers;
using UnityEngine;

public class JumpingBoss : MonoBehaviour
{
    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        StartCoroutine(nameof(Jump));        
    }


    public float jumpForce;
    IEnumerator Jump()
    {
        while (true)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            yield return new WaitForSeconds(2f);
        }
    }
}
