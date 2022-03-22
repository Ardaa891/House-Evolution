using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PriceGenerator : MonoBehaviour
{
    public static PriceGenerator Current;
    public GameObject totalPriceTextBox;
    public GameObject priceTextBox;
    public GameObject nextOfferButton;
    public float clickNumber = 0;
    public float price;
    public float totalPrice;
    
   

    private void Start()
    {
        Current = this;
        price = Random.Range(1000, 3000);
        priceTextBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = price + " $";

        
    }

    /*private void Update()
    {
        totalPrice = price;
    }*/

    public void Generator()
    {
        clickNumber++;
        

            price = Random.Range(2500, 5000);
            priceTextBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = price + " $";
            priceTextBox.transform.DOScale(1.5f, 0.4f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo);
        
        
           
        
        if (clickNumber == 2)
        {
            //nextOfferButton.GetComponent<Image>().material = disableButtonMat;
            nextOfferButton.GetComponent<Button>().interactable = false;
            price = Random.Range(1000, 4000);
            priceTextBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = price + " $";
            priceTextBox.transform.DOScale(1.5f, 0.4f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo);

        }
    }


}
