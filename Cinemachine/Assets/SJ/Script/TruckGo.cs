using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckGo : MonoBehaviour
{
    [SerializeField]
    private GameObject truck;

    private void Awake()
    {
        truck.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
        truck.SetActive(true);
        }
    }
}
