using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class Gate : MonoBehaviour
{

    public static Gate Current;
    public TextMeshProUGUI _date;

    public float date;
    
    
    void Start()
    {
        Current = this;
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
