using System.Collections;
using System.Collections.Generic;
using Unity.Sentis.Layers;
using UnityEngine;

public class JumpingBoss : MonoBehaviour
{
    Rigidbody body;
    public GameObject player;
    public float rotationSpeed;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        StartCoroutine(nameof(Jump));        
    }

    private void Update()
    {
        Vector3 direction = transform.position - player.transform.position;
        direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

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
