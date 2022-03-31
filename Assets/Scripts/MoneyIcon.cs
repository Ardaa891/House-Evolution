using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoneyIcon : MonoBehaviour
{
    public static MoneyIcon Current;
    Sequence seq1;
    Sequence seq2;
    public Image moneyIcon1, moneyIcon2, moneyIcon3, moneyIcon4, moneyIcon5, moneyIcon6, moneyIcon7, moneyIcon8, moneyIcon9, moneyIcon10;
    public Vector3 imageTransform;
    public Image moneyicon;
    



    void Start()
    {
        Current = this;
        DOTween.Init();
        seq1 = DOTween.Sequence();
        seq2 = DOTween.Sequence();
        //imageTransform = new Vector3(moneyicon.rectTransform.position.x, moneyicon.rectTransform.position.y, moneyicon.rectTransform.position.z);
    }

    
    public void MoneyIconMove()
    {
        seq1.Join(moneyIcon1.rectTransform.DOLocalMove(new Vector2(372, 1470f), 0.5f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon2.rectTransform.DOLocalMove(new Vector2(372, 1470f), 0.5f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon3.rectTransform.DOLocalMove(new Vector2(372, 1470f), 0.5f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon4.rectTransform.DOLocalMove(new Vector2(372, 1470f), 0.5f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon5.rectTransform.DOLocalMove(new Vector2(372, 1470f), 0.5f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon6.rectTransform.DOLocalMove(new Vector2(372, 1470f), 0.5f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon7.rectTransform.DOLocalMove(new Vector2(372, 1470f), 0.5f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon8.rectTransform.DOLocalMove(new Vector2(372, 1470f), 0.5f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon9.rectTransform.DOLocalMove(new Vector2(372, 1470f), 0.5f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon10.rectTransform.DOLocalMove(new Vector2(372, 1470f), 0.5f).SetEase(Ease.Linear));

        seq1.Join(moneyIcon1.rectTransform.DOScale(new Vector3(0,0,0), 0.75f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon2.rectTransform.DOScale(new Vector3(0, 0, 0), 0.75f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon3.rectTransform.DOScale(new Vector3(0, 0, 0), 0.75f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon4.rectTransform.DOScale(new Vector3(0, 0, 0), 0.75f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon5.rectTransform.DOScale(new Vector3(0, 0, 0), 0.75f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon6.rectTransform.DOScale(new Vector3(0, 0, 0), 0.75f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon7.rectTransform.DOScale(new Vector3(0, 0, 0), 0.75f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon8.rectTransform.DOScale(new Vector3(0, 0, 0), 0.75f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon9.rectTransform.DOScale(new Vector3(0, 0, 0), 0.75f).SetEase(Ease.Linear));
        seq1.Join(moneyIcon10.rectTransform.DOScale(new Vector3(0, 0, 0), 0.75f).SetEase(Ease.Linear));
    }
}
