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
    public Camera cam;
    public GameObject _cam;
    
    
    public Material  gateMaterial, badGateMaterial;

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
                offset = Mathf.Clamp(offset, -6f, 7f);
                transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, yOffset);

                if (touchXDelta >= -6f && touchXDelta < 0)
                {
                    
                    //transform.GetComponent<SplineFollower>().motion.rotationOffset += new Vector3(0, -rotY)*5*Time.fixedDeltaTime;
                    transform.DORotate(new Vector3(0, -6, 0), 0.2f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(()=>Rot());




                }
                else if (touchXDelta <= 7f && touchXDelta > 0)
                {
                    
                    transform.DORotate(new Vector3(0, 24, 0), 0.2f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(() => Rot1());




                }

            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                
                touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
                offset = transform.GetComponent<SplineFollower>().motion.offset.x + 25f * touchXDelta * Time.fixedDeltaTime;
                offset = Mathf.Clamp(offset, -7f, 7f);
                transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, yOffset );

                if (touchXDelta >= -7f && touchXDelta < 0)
                {
                    transform.DORotate(new Vector3(0, -15, 0), 0.2f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(() => Rot1());




                }
                else if (touchXDelta <= 7f && touchXDelta > 0)
                {
                    transform.DORotate(new Vector3(0, 15, 0), 0.2f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(() => Rot());
                }

            }

            

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
            
            
            //LevelController.Current.cam.GetComponent<SplineFollower>().follow = false;
            seq.Join(cam.transform.DOLookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z), 1f, AxisConstraint.X).SetEase(Ease.Linear));
            seq.Join(cam.transform.DOLocalMove(new Vector3(0f, 2, 30), 2f).SetEase(Ease.Linear));
            seq.Join(cam.transform.DOLocalRotate(new Vector3(0, 0, 0), 1f).SetEase(Ease.Linear));
            GetComponent<SplineFollower>().motion.offset = new Vector3(0, yOffset);
            //_cam.transform.DOLocalRotate(new Vector3(0, 360.176f, 0), 1f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
            

        }
        if (other.CompareTag("camEnd"))
        {
            LevelController.Current.cam.GetComponent<SplineFollower>().follow = false;
        }
        if (other.CompareTag("finish"))
        {
            transform.DOLocalRotate(new Vector3(0, 720, 0), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);
            LevelController.Current.gameActive = false;
            LevelController.Current.finishGameMenu.SetActive(true);
            follower.follow = false;
        }



        if (other.CompareTag("Gate"))
        {
            IncreaseScore(5);
            //other.gameObject.SetActive(false);
            transform.DOScale(1.1f, 0.3f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            //ColorUtility.TryParseHtmlString("D6D6D6", out color1);
            //other.GetComponent<Image>().color = color1;
            other.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = gateMaterial;



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
                englishHouse.SetActive(false);
                dutchHouse.SetActive(false);
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
            //other.gameObject.SetActive(false);
            transform.DOScale(1.1f, 0.3f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            //ColorUtility.TryParseHtmlString("D6D6D6", out color1);
            other.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = badGateMaterial;

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
                /*seq.Join(tudorHouse.transform.DOLocalRotate(new Vector3(0, 890, 0), 0.7f).SetEase(Ease.OutQuad));
                seq.Join(tudorHouse.transform.DOLocalMoveY(2.15f, 0.3f)).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutQuad);
                seq.Join(tudorHouse.transform.DOScale(1, 0.7f)).SetEase(Ease.InOutQuad);*/
                
            }

            if (score > 10 && score < 20)
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

    }

    public void IncreaseScore(int increment)
    {
        score += increment;
    }

    public void DecreaseScore(int increment)
    {
        score -= increment;
    }

    void Rot()
    {
        transform.DOLocalRotate(new Vector3(0,9.26f,0), 0.2f, RotateMode.Fast).SetEase(Ease.Linear);
    }

    void Rot1()
    {
        transform.DOLocalRotate(new Vector3(0,9.26f,0), 0.2f, RotateMode.Fast).SetEase(Ease.Linear);
    }

}
