using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Dreamteck.Splines;
using MoreMountains.NiceVibrations;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Currrent;

    public float speed;
    private float _currentSpeed;
    
    public float limitX;
    Rigidbody rb;
    public SplineFollower follower;
    public GameObject playButton;
    public GameObject House1, House2, House3, House4, House5, House6;
    public float offset;
    public float yOffset ;
    public float calendarOffset;
    public Material skyboxMat;
    Sequence seq;
    Sequence seq1;
    public float score = 0;
    public int date;
    public Camera cam;
    public GameObject _cam;
    public GameObject calendar;
    public TextMeshProUGUI popup;
    public Material  gateMaterial, badGateMaterial;
    public GameObject Light;
    public GameObject ticket;
    
    private void Awake()
    {
       
        Currrent = this;
        follower = GetComponent<SplineFollower>();
        //offset = new Vector2(xOffset, 0);
        seq = DOTween.Sequence();
        seq1 = DOTween.Sequence();
        
        
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


            /*if (score >= 10)
            {

                House1.SetActive(false);
                House2.SetActive(true);
                //calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1625s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);

                //popup.rectTransform.DOScale(1, 1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);


            }

            if (score >= 20)
            {
                House3.SetActive(true);
                House2.SetActive(false);
                //calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1650s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if (score >= 30)
            {
                House3.SetActive(false);
                House4.SetActive(true);
                //englishHouse.SetActive(false);
                //dutchHouse.SetActive(false);
                //calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1675s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if (score >= 40)
            {
                House4.SetActive(false);
                House5.SetActive(true);
               // calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1700s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }
            if (score >= 45)
            {
                House5.SetActive(false);
                
                House6.SetActive(true);
               // calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1725s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if (score < 10)
            {
                House2.SetActive(false);
                House1.SetActive(true);
                //calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1600s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if (score > 10 && score < 20)
            {
                House3.SetActive(false);
                House2.SetActive(true);
                //calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1625s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if (score > 20 && score < 30)
            {
                House3.SetActive(true);
                House4.SetActive(false);
                //calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1650s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }

            if (score > 30 && score < 40)
            {
                House4.SetActive(true);
                House5.SetActive(false);
                
                //calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1675s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }
            if (score > 40 && score < 45)
            {
                House6.SetActive(false);
                House5.SetActive(true);
                
                //calendar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1700s";
                calendar.transform.GetChild(0).GetChild(0).GetChild(0).transform.DOScale(1.2f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            }*/

            if (score < 10)
            {
                House2.SetActive(false);
                House1.SetActive(true);
                House3.SetActive(false);
                House4.SetActive(false);
                House5.SetActive(false);
                House6.SetActive(false);
            }

            if(score >= 10 && score < 20)
            {
                House1.SetActive(false);
                House2.SetActive(true);
                House4.SetActive(false);
                House3.SetActive(false);
                House5.SetActive(false);
                House6.SetActive(false);
            }
            if(score >=20 && score < 30)
            {
                House3.SetActive(true);
                House2.SetActive(false);
                House1.SetActive(false);
                House4.SetActive(false);
                House5.SetActive(false);
                House6.SetActive(false);
            }
            if(score >= 30 && score < 40)
            {
                House3.SetActive(false);
                House4.SetActive(true);
                House1.SetActive(false);
                House2.SetActive(false);
                House5.SetActive(false);
                House6.SetActive(false);
            }
            if(score >= 40 && score < 45)
            {
                House5.SetActive(true);
                House4.SetActive(false);
                House1.SetActive(false);
                House2.SetActive(false);
                House3.SetActive(false);
                House6.SetActive(false);
            }
            if(score >= 45)
            {
                House6.SetActive(true);
                House5.SetActive(false);
                House1.SetActive(false);
                House2.SetActive(false);
                House3.SetActive(false);
                House4.SetActive(false);
            }
            
            
            
            
            
            
            if (Input.GetMouseButton(0))
            {
               
                touchXDelta = Input.GetAxis("Mouse X");
                offset = transform.GetComponent<SplineFollower>().motion.offset.x +  25f * touchXDelta * Time.fixedDeltaTime;
                offset = Mathf.Clamp(offset, -6f, 7f);
                calendarOffset = transform.GetComponent<SplineFollower>().motion.offset.x + 30f * touchXDelta * Time.fixedDeltaTime;
                calendarOffset = Mathf.Clamp(calendarOffset, -6f, 7f);
                transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, yOffset);
                calendar.transform.GetComponent<SplineFollower>().motion.offset = new Vector3(calendarOffset, 0.7f);
                
               
                if (touchXDelta >= -6f && touchXDelta < 0)
                {
                    transform.DORotate(new Vector3(0, -6, 0), 0.35f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(()=>Rot());

                }
                else if (touchXDelta <= 7f && touchXDelta > 0)
                {
                    transform.DORotate(new Vector3(0, 24, 0), 0.35f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(() => Rot1());

                }

            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                
                touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
                offset = transform.GetComponent<SplineFollower>().motion.offset.x + 25f * touchXDelta * Time.fixedDeltaTime;
                offset = Mathf.Clamp(offset, -6f, 7f);
                calendarOffset = transform.GetComponent<SplineFollower>().motion.offset.x + 30f * touchXDelta * Time.fixedDeltaTime;
                calendarOffset = Mathf.Clamp(calendarOffset, -6f, 7f);
                transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, yOffset );
                calendar.transform.GetComponent<SplineFollower>().motion.offset = new Vector3(calendarOffset, 0.7f);
               

                if (touchXDelta >= -6f && touchXDelta < 0)
                {
                    transform.DORotate(new Vector3(0, -6, 0), 0.35f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(() => Rot1());

                }
                else if (touchXDelta <= 7f && touchXDelta > 0)
                {
                    transform.DORotate(new Vector3(0, 24, 0), 0.35f, RotateMode.Fast).SetEase(Ease.Linear).OnComplete(() => Rot());
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
            transform.DOScale(1.05f, 0.15f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            IncreaseScore(-5);
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
        }
       


        if (other.CompareTag("End"))
        {
            seq.Join(cam.transform.DOLookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z), 1f, AxisConstraint.X).SetEase(Ease.Linear));
            seq.Join(cam.transform.DOLocalMove(new Vector3(0f, 2, 30), 2f).SetEase(Ease.Linear));
            seq.Join(cam.transform.DOLocalRotate(new Vector3(0, 0, 0), 1f).SetEase(Ease.Linear));
            GetComponent<SplineFollower>().motion.offset = new Vector3(0, yOffset);
            GetComponent<SplineFollower>().motion.rotationOffset = new Vector3(0, 9);
            //LevelController.Current.calendar.GetComponent<SplineFollower>().follow = false;
            //calendar.SetActive(false);
            LevelController.Current.gameActive = false;
            RenderSettings.skybox = skyboxMat;
            Camera.main.clearFlags = CameraClearFlags.Skybox;
            Light.transform.DORotate(new Vector3(142,147,90), 1);
            CalendarController.Current.StopFollowing();
            MMVibrationManager.Haptic(HapticTypes.Success);

        }
        if (other.CompareTag("camEnd"))
        {
            // LevelController.Current.cam.GetComponent<SplineFollower>().follow = false;
            CameraFollower.Current.StopFollowing();
        }
        if (other.CompareTag("finish"))
        {
            transform.DOLocalRotate(new Vector3(0, 720, 0), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);
            // LevelController.Current.gameActive = false;
            LevelController.Current.finishGameMenu.SetActive(true);
            LevelController.Current.levelStartMenu.SetActive(false);
            ticket.SetActive(true);
            follower.follow = false;
            LevelController.Current.APKGameSuccess();
           

        }



        if (other.CompareTag("Gate"))
        {
            float gateDate = other.GetComponent<Gate>().date;
            IncreaseScore(gateDate);
            transform.DOScale(1.05f, 0.15f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            other.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = gateMaterial;
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);

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
