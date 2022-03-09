using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Dreamteck.Splines;

public class SwerveSystem : MonoBehaviour
{
    public static SwerveSystem Current;

    [SerializeField] private float swerveSpeed = 0.5f;
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
   private float MoveFactorX => _moveFactorX;

    public float speed = 0f;
    public bool isMoveForward = false;
    public bool isParent = false;

    public float swerveMinus;
    public float swervePlus;


    public Transform parentObject;

    Rigidbody rb;
    public SplineFollower follower;
    public GameObject playButton;
    public GameObject cube, sphere, capsule, cylinder;
    Sequence seq;


    private void Start()
    {
        Current = this;
        follower = GetComponent<SplineFollower>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;
        DOTween.Init();
        rb = GetComponent<Rigidbody>();
        seq = DOTween.Sequence();
    }





    private void Update()
    {
        if (LevelController.Current.gameActive)
        {

            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
            }
            Movement();
            Swerve();

        }else
        {
            return;
        }
    }


    void Movement()
    {
        if(isMoveForward)
        {
            switch(isParent){
                case true:
                parentObject.Translate(0, 0, speed * Time.fixedDeltaTime);
                break;

                case false:
                transform.Translate(0, 0, speed * Time.fixedDeltaTime);
                break;
            }
        }
    }

    void Swerve()
    {   float swerveAmount = Time.fixedDeltaTime * swerveSpeed * MoveFactorX;
        switch(isParent){
            case true:
            if(MoveFactorX<=0 && parentObject.position.x>swerveMinus)
            {
                parentObject.Translate(swerveAmount, 0, 0);
            } 
            if(MoveFactorX>0 && parentObject.position.x<swervePlus)
            {
                parentObject.Translate(swerveAmount, 0, 0);
            }           
            break;

            case false:
            if(MoveFactorX>=0 && transform.position.x>swerveMinus)
            {
                transform.Translate(swerveAmount, 0, 0);
            } 
            if(MoveFactorX>0 && transform.position.x<swervePlus)
            {
                transform.Translate(swerveAmount, 0, 0);
            }      
              
            break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            seq.Join(cube.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce));
            seq.Join(sphere.transform.DOScale(100, 1f).SetEase(Ease.InOutBounce));
            seq.Join(sphere.transform.DOLocalRotate(new Vector3(0, 1080, 0), 1f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
            seq.Join(sphere.transform.DOMoveY(3, 0.5f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo));
            //cube.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce);
            sphere.SetActive(true);
            //sphere.transform.DOScale(100, 1f).SetEase(Ease.InOutBounce);
            other.gameObject.SetActive(false);


        }

        if (other.CompareTag("Gate2"))
        {
            cube.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce);
            sphere.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce);
            capsule.SetActive(true);
            capsule.transform.DOScale(2, 1f).SetEase(Ease.InOutBounce);
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Gate3"))
        {
            sphere.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce);
            cube.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce);
            capsule.transform.DOScale(0, 0.2f).SetEase(Ease.InBounce);
            cylinder.SetActive(true);
            cylinder.transform.DOScale(2, 1f).SetEase(Ease.InOutBounce);
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
