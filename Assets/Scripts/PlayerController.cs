using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Dreamteck.Splines;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Currrent;

    public float speed;
    private float _currentSpeed;
    public float xSpeed;
    public float limitX;
    Rigidbody rb;
    public SplineFollower follower;
    public GameObject playButton;
    public GameObject tudorHouse, dutchHouse, frenchHouse, spanishHouse, englishHouse;
    public float offset;
    public float yOffset ;
    Sequence seq;
    public int score = 0;

    private void Awake()
    {
        Currrent = this;
        follower = GetComponent<SplineFollower>();
        //offset = new Vector2(xOffset, 0);
        seq = DOTween.Sequence();
        
    }





    void Start()
    {
       
        _currentSpeed = speed;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;
        DOTween.Init();
        rb = GetComponent<Rigidbody>();
        yOffset = transform.GetComponent<SplineFollower>().motion.offset.y;
    }

    
    void FixedUpdate()
    {
        


        if (LevelController.Current.gameActive)
        {

            

            float touchXDelta = 0;

            
            
            
            if (Input.GetMouseButton(0))
            {
               
                touchXDelta = Input.GetAxis("Mouse X");
                offset = transform.GetComponent<SplineFollower>().motion.offset.x +  25f * touchXDelta * Time.fixedDeltaTime;
                offset = Mathf.Clamp(offset, -7f, 7f);
                transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, yOffset);
                
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                
                touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
                offset = transform.GetComponent<SplineFollower>().motion.offset.x + 25f * touchXDelta * Time.fixedDeltaTime;
                offset = Mathf.Clamp(offset, -9f, 9f);
                transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, yOffset );

            }

            /*if (score >= 10 )
            {
                
                cube.SetActive(false);
                house1.SetActive(true);
               
            }

            if (score >= 20)
            {
                house2.SetActive(true);
                house1.SetActive(false);
                
            }

            if(score < 10)
            {
                house1.SetActive(false);
                cube.SetActive(true);
            }*/

        }
        else
        {
            return;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
       


        if (other.CompareTag("End"))
        {
            LevelController.Current.gameActive = false;
            LevelController.Current.finishGameMenu.SetActive(true);
            follower.follow = false;
        }



        if (other.CompareTag("Gate"))
        {
            IncreaseScore(5);
            other.gameObject.SetActive(false);
            if (score >= 10)
            {

                tudorHouse.SetActive(false);
                dutchHouse.SetActive(true);
                


            }

            if (score >= 20)
            {
                frenchHouse.SetActive(true);
                dutchHouse.SetActive(false);

            }

            if(score >= 30)
            {
                frenchHouse.SetActive(false);
                spanishHouse.SetActive(true);
            }
            
            if (score >= 40)
            {
                spanishHouse.SetActive(false);
                englishHouse.SetActive(true);
            }

            if (score < 10)
            {
                dutchHouse.SetActive(false);
                tudorHouse.SetActive(true);
            }

            if(score > 10 && score < 20)
            {
                frenchHouse.SetActive(false);
                dutchHouse.SetActive(true);
            }

            if (score > 20 && score < 30)
            {
                frenchHouse.SetActive(true);
                spanishHouse.SetActive(false);
            }

            if (score > 30 && score < 40)
            {
                spanishHouse.SetActive(true);
                englishHouse.SetActive(false);
            }
        }

        if (other.CompareTag("BadGate"))
        {
            DecreaseScore(5);
            other.gameObject.SetActive(false);
            if (score >= 10)
            {

                tudorHouse.SetActive(false);
                dutchHouse.SetActive(true);

            }

            if (score >= 20)
            {
                frenchHouse.SetActive(true);
                dutchHouse.SetActive(false);

            }

            if (score < 10)
            {
                dutchHouse.SetActive(false);
                tudorHouse.SetActive(true);
            }
        }

    }

    public void IncreaseScore(int increment)
    {
        score += increment;
    }

    public void DecreaseScore(int increment)
    {
        score -= increment;
    }

}
