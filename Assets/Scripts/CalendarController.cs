using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;

public class CalendarController : MonoBehaviour
{
    public static CalendarController Current;
    
    void Start()
    {
        Current = this;
        GetComponent<SplineFollower>().follow = false;
    }

    
    void Update()
    {
        
    }

    public void StartFollowing()
    {
        GetComponent<SplineFollower>().follow = true;
        transform.DOScale(1, 0.2f).SetEase(Ease.Linear);
    }

    public void StopFollowing()
    {
        GetComponent<SplineFollower>().follow = false;
        gameObject.SetActive(false);
    }
}
