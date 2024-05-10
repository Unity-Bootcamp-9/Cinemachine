using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    // ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫
    private static SceneChanger instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.PageDown))
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int nextIndex = currentIndex + 1;

            if(nextIndex < 3)
            {
               SceneManager.LoadScene(nextIndex);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
