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
    public GameObject cube, sphere, capsule, cylinder;
    public float offset;
    Sequence seq;

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
                transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, transform.GetComponent<SplineFollower>().motion.offset.y);
                
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
                offset = transform.GetComponent<SplineFollower>().motion.offset.x + 25f * touchXDelta * Time.fixedDeltaTime;
                offset = Mathf.Clamp(offset, -9f, 9f);
                transform.GetComponent<SplineFollower>().motion.offset = new Vector3(offset, transform.GetComponent<SplineFollower>().motion.offset.y);

            }


            
        }
        else
        {
            return;
        }
       
        
        
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            seq.Join(cube.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce));
            seq.Join(sphere.transform.DOScale(100, 1f).SetEase(Ease.InOutBounce));
            seq.Join(sphere.transform.DOLocalRotate(new Vector3(0, 1080, 0), 1f, RotateMode.Fast).SetEase(Ease.Linear));
            seq.Join(sphere.transform.DOMoveY(3, 0.5f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo));
            //cube.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce);
            sphere.SetActive(true);
            cylinder.SetActive(false);
            //sphere.transform.DOScale(100, 1f).SetEase(Ease.InOutBounce);
            other.gameObject.SetActive(false);

           
        }

        if (other.CompareTag("Gate2"))
        {
            seq.Join(cube.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce));
            seq.Join(sphere.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce));
            capsule.SetActive(true);
            seq.Join(capsule.transform.DOScale(2, 1f).SetEase(Ease.InOutBounce));
            seq.Join(capsule.transform.DOLocalRotate(new Vector3(0, 1080, 0), 1f, RotateMode.Fast).SetEase(Ease.Linear));
            seq.Join(capsule.transform.DOMoveY(3, 0.5f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo));
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Gate3"))
        {
            seq.Join(sphere.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce));
            seq.Join(cube.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce));
            seq.Join(capsule.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce));
            cylinder.SetActive(true);
            seq.Join(cylinder.transform.DOScale(2, 1f).SetEase(Ease.InOutBounce));
            seq.Join(cylinder.transform.DOMoveY(3, 0.5f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo));
            seq.Join(cylinder.transform.DOLocalRotate(new Vector3(0, 1080, 0), 1f, RotateMode.Fast).SetEase(Ease.Linear));
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("End"))
        {
            LevelController.Current.gameActive = false;
            LevelController.Current.finishGameMenu.SetActive(true);
            follower.follow = false;
        }
    }

}
