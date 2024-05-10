using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class truckMove : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Rigidbody Rigidbody;
    private float time = 0.0f;
    private float speed = 8f;
    private Vector3 vec;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        vec = target.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        if (time > 2.0f)
        {
            Rigidbody.velocity += vec * Time.deltaTime * speed;
            //Rigidbody.AddForce (vec * (Time.deltaTime* speed), ForceMode.Impulse);
            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
        
        speed = 0.0f;
        }
    }

}
