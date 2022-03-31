using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class canvas : MonoBehaviour
{
    public static canvas Current;

    // Start is called before the first frame update
    void Start()
    {
        Current = this;
        
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ("lvl " + (PlayerPrefs.GetInt("level") + 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
