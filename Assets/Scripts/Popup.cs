using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    public static Popup Current;
    public Transform text;
    float textHeight;
    public GameObject parent;

    void Start()
    {
        Current = this;
    }


    public void EatTexter(int date)
    {
        float randomPos = Random.Range(-2, 2);
        Transform textTemp = Instantiate(text, new Vector3(randomPos, textHeight, parent.transform.position.z), Quaternion.identity, parent.transform);
        //textTemp.GetComponent<TextMeshPro>().text = date.ToString() ;
        textTemp.transform.DOMoveY(textHeight + 2, 1f, false);
        textTemp.transform.DOScale(1f, 1f);
        StartCoroutine(TurnOffText(textTemp));
    }
    IEnumerator TurnOffText(Transform textTemp)
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(textTemp.gameObject);
    }
}
