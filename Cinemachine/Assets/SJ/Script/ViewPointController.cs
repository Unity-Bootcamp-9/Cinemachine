using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.Timeline.Actions;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class ViewPointController : MonoBehaviour
{
    public CinemachineDollyCart dollyCart;
    
    [SerializeField]
    private List<GameObject> viewPoint;
    [SerializeField]    
    private GameObject dollyCamera;
    private int runningShot = 0;
    private int viewPointCount;
    private PlayableDirector dollyDirector;
    void Start()
    {

        foreach (var view in viewPoint)
        {
            view.SetActive(false);
        }
        viewPoint[runningShot].SetActive(true);
        viewPointCount = viewPoint.Count;

        var path = dollyCart.m_Path;
        Debug.Log(path.PathLength);

       dollyDirector = Camera.main.GetComponent<PlayableDirector>();

    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            viewPoint[runningShot].SetActive(false);
            runningShot++;
            Debug.Log(runningShot.ToString());
            if(runningShot >= viewPointCount)
            {
                runningShot = 0;
            }
            viewPoint[runningShot].SetActive(true);
        }
    }
}
