using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class EnglishHome : MonoBehaviour
{
    public static EnglishHome current;
    Sequence seq;
    
    
    
    void Start()
    {
        current = this;
        seq = DOTween.Sequence();

        
        
    }

    private void OnEnable()
    {
        //seq.Join(transform.DOScale(1, 0.7f).SetEase(Ease.InOutQuad));
        //seq.Join(transform.DOLocalRotate(new Vector3(0, 890, 0), 0.7f, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad));
        //seq.Join(transform.DOLocalMove(new Vector3(0, 2.15f, 0), 0.3f).SetEase(Ease.OutQuad).SetLoops(2, LoopType.Yoyo));
    }

    /*private void OnDisable()
    {
        transform.localScale = Vector3.zero;
        transform.localRotation = Quaternion.Euler(0, 170, 0);
        
    }*/


}
