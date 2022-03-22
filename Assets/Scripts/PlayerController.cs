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
    public float rotOffset;
    Sequence seq;
    public float score = 0;
    public int date;
    public Camera cam;
    public GameObject _cam;
    public GameObject calendar;
    
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
                calendar.transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, yOffset);
                /*rotOffset = transform.GetComponent<SplineFollower>().motion.rotationOffset.y + 100f* touchXDelta * Time.fixedDeltaTime;
                rotOffset = Mathf.Clamp(rotOffset, -6f, 24f);
                transform.GetComponent<SplineFollower>().motion.rotationOffset = new Vector3(0, rotOffset);*/

               
                if (touchXDelta >= -6f && touchXDelta < 0)
                {
                    
                    //transform.GetComponent<SplineFollower>().motion.rotationOffset += new Vector3(0, -rotY)*5*Time.fixedDeltaTime;
                    transform.DORotate(new Vector3(0, -5, 0), 0.2f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(()=>Rot());

                }
                else if (touchXDelta <= 7f && touchXDelta > 0)
                {
                    transform.DORotate(new Vector3(0, 23, 0), 0.2f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(() => Rot1());

                }

            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                
                touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
                offset = transform.GetComponent<SplineFollower>().motion.offset.x + 25f * touchXDelta * Time.fixedDeltaTime;
                offset = Mathf.Clamp(offset, -7f, 7f);
                transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, yOffset );
                calendar.transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, yOffset);
                /*rotOffset = transform.GetComponent<SplineFollower>().motion.rotationOffset.y + 25f* touchXDelta*Time.fixedDeltaTime;
                rotOffset = Mathf.Clamp(rotOffset, -6f, 24f);
                transform.GetComponent<SplineFollower>().motion.rotationOffset = new Vector3(0, rotOffset);*/

                if (touchXDelta >= -7f && touchXDelta < 0)
                {
                    transform.DORotate(new Vector3(0, -6, 0), 0.2f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(() => Rot1());




                }
                else if (touchXDelta <= 7f && touchXDelta > 0)
                {
                    transform.DORotate(new Vector3(0, 24, 0), 0.2f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(() => Rot());
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
        if (other.CompareTag("trap"))
        {
            transform.DOScale(1.1f, 0.3f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            IncreaseScore(-5);
            //transform.DOShakePosition(1f, new Vector3(1, 0, 0), 50, 1, false, true);
        }
       


        if (other.CompareTag("End"))
        {
            seq.Join(cam.transform.DOLookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z), 1f, AxisConstraint.X).SetEase(Ease.Linear));
            seq.Join(cam.transform.DOLocalMove(new Vector3(0f, 2, 30), 2f).SetEase(Ease.Linear));
            seq.Join(cam.transform.DOLocalRotate(new Vector3(0, 0, 0), 1f).SetEase(Ease.Linear));
            GetComponent<SplineFollower>().motion.offset = new Vector3(0, yOffset);
            GetComponent<SplineFollower>().motion.rotationOffset = new Vector3(0, 9);
            LevelController.Current.calendar.GetComponent<SplineFollower>().follow = false;
            calendar.SetActive(false);
            LevelController.Current.gameActive = false;    


        }
        if (other.CompareTag("camEnd"))
        {
            LevelController.Current.cam.GetComponent<SplineFollower>().follow = false;
        }
        if (other.CompareTag("finish"))
        {
            transform.DOLocalRotate(new Vector3(0, 720, 0), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);
            // LevelController.Current.gameActive = false;
            LevelController.Current.finishGameMenu.SetActive(true);
            LevelController.Current.levelStartMenu.SetActive(false);
            follower.follow = false;

        }



        if (other.CompareTag("Gate"))
        {
            float gateDate = other.GetComponent<Gate>().date;
            IncreaseScore(gateDate);
            transform.DOScale(1.1f, 0.3f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            other.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = gateMaterial;



            if (score >= 10)
            {

                tudorHouse.SetActive(false);
                dutchHouse.SetActive(true);
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1400s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if (score >= 20)
            {
                frenchHouse.SetActive(true);
                dutchHouse.SetActive(false);
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1500s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if(score >= 30)
            {
                frenchHouse.SetActive(false);
                spanishHouse.SetActive(true);
                englishHouse.SetActive(false);
                dutchHouse.SetActive(false);
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1600s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }
            
            if (score >= 40)
            {
                spanishHouse.SetActive(false);
                englishHouse.SetActive(true);
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1700s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if (score < 10)
            {
                dutchHouse.SetActive(false);
                tudorHouse.SetActive(true);
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1300s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if(score > 10 && score < 20)
            {
                frenchHouse.SetActive(false);
                dutchHouse.SetActive(true);
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1400s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if (score > 20 && score < 30)
            {
                frenchHouse.SetActive(true);
                spanishHouse.SetActive(false);
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1500s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if (score > 30 && score < 40)
            {
                spanishHouse.SetActive(true);
                englishHouse.SetActive(false);
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1600s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }
        }

        

    }

    public void IncreaseScore(float increment)
    {
        score += increment;
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
