using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    static SceneChanger instance;

    void Start()
    {
        DontDestroyOnLoad(this);    
    }

    void Update()
    {   
    }
}
