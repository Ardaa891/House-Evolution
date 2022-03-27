using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
public class CameraFollower : MonoBehaviour
{
    public static CameraFollower Current;


    void Start()
    {
        Current = this;
        gameObject.GetComponent<SplineFollower>().follow = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFollowing()
    {
        GetComponent<SplineFollower>().follow = true;
    }

    public void StopFollowing()
    {
        GetComponent<SplineFollower>().follow = false;
    }
}
