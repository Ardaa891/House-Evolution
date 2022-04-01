using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Dreamteck.Splines;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using ElephantSDK;


public class LevelController : MonoBehaviour
{
    public static LevelController Current;
    public List<GameObject> levels = new List<GameObject>();
    public GameObject levelStartMenu, gameOverMenu, finishGameMenu;
    public bool gameActive = false;
    public GameObject cam;
    public GameObject calendar;
    public GameObject moneyIcons;
    public GameObject totalPriceTextBox;
    public int money;

    protected bool apkStart = true;
    
    protected bool apkSuccess = true;

    [Space]
    [Space]
    public GameObject CurrentLevel;
    public bool isTesting = false;


    private void Awake()
    {
        
        Current = this;

        if (isTesting == false)
        {

            if (levels.Count == 0)
            {

                foreach (Transform level in transform)
                {
                    levels.Add(level.gameObject);
                }
            }


            CurrentLevel = levels[PlayerPrefs.GetInt("level") % levels.Count];
            levels[PlayerPrefs.GetInt("level") % levels.Count].SetActive(true);
        }
        else
        {
            CurrentLevel.SetActive(true);
        }

       
    }



    void Start()
    {
        money = PlayerPrefs.GetInt("money", 0);
       totalPriceTextBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("money", 0).ToString();
    }

    
    void Update()
    {
        
    }

    public void NextLevel()
    {
        UpdateMoney();
        moneyIcons.SetActive(true);
        StartCoroutine(IconMove());
        StartCoroutine(LoadNextLevel());
        MMVibrationManager.Haptic(HapticTypes.Selection);

        /*if ((levels.IndexOf(CurrentLevel) + 1) == levels.Count)
        {




            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);



            //  GameHandler.Instance.Appear_TransitionPanel();


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        }


        else
        {
            CurrentLevel = levels[(PlayerPrefs.GetInt("level") + 1) % levels.Count];



            levels[(PlayerPrefs.GetInt("level")) % levels.Count].SetActive(false);


            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);

            levels[PlayerPrefs.GetInt("level") % levels.Count].SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }*/
    }

    public void StartLevel()
    {
        APKGameStart();
        gameActive = true;
        PlayerController.Currrent.playButton.SetActive(false);
        PlayerController.Currrent.follower.follow = true;
        levelStartMenu.SetActive(false);
        CameraFollower.Current.StartFollowing();
        
        CalendarController.Current.StartFollowing();

       
    }

    public void UpdateMoney()
    {




        //PriceGenerator.Current.totalPriceTextBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PriceGenerator.Current.price.ToString();
        PlayerPrefs.SetInt("money", money + PriceGenerator.Current.price);
        totalPriceTextBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("money").ToString();
    }

    

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(3f);

        if ((levels.IndexOf(CurrentLevel) + 1) == levels.Count)
        {




            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);



            //  GameHandler.Instance.Appear_TransitionPanel();


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        }


        else
        {
            CurrentLevel = levels[(PlayerPrefs.GetInt("level") + 1) % levels.Count];



            levels[(PlayerPrefs.GetInt("level")) % levels.Count].SetActive(false);


            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);

            levels[PlayerPrefs.GetInt("level") % levels.Count].SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    IEnumerator IconMove()
    {
        yield return new WaitForSecondsRealtime(1f);
        MoneyIcon.Current.MoneyIconMove();
    }

    public void APKGameStart()
    {
        if (apkStart)
        {
            Elephant.LevelStarted(PlayerPrefs.GetInt("level") + 1);
            apkStart = false;
        }
    }

    public void APKGameSuccess()
    {
        if (apkSuccess)
        {
            Elephant.LevelCompleted(PlayerPrefs.GetInt("level") + 1);
            apkSuccess = false;
        }
    }
}
