using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PriceGenerator : MonoBehaviour
{
    public static PriceGenerator Current;
   
    public GameObject priceTextBox;
    public GameObject nextOfferButton;
    public float clickNumber = 0;
    public int price;
    
    
    
    public int minPrice1, minPrice2, minPrice3, maxPrice1, maxPrice2, maxPrice3;
    
   

    private void Start()
    {
        Current = this;
        price = Random.Range(minPrice1, maxPrice1);
        priceTextBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = price + " $";

        
        
    }

    /*private void Update()
    {
        totalPrice = price;
    }*/

    public void Generator()
    {
        clickNumber++;
        Debug.Log(clickNumber);

            price = Random.Range(minPrice2, maxPrice2);
            priceTextBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = price + " $";
            priceTextBox.transform.DOScale(1.5f, 0.4f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo);
        
        
           
        
        if (clickNumber == 2)
        {
            
            

            nextOfferButton.GetComponent<Button>().interactable = false;
            price = Random.Range(minPrice3, maxPrice3);
            priceTextBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = price + " $";
            priceTextBox.transform.DOScale(1.5f, 0.4f).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo);

        }
    }


}
