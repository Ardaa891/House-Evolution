using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Dreamteck.Splines;
using DG.Tweening;

public class LevelController : MonoBehaviour
{
    public static LevelController Current;
    public List<GameObject> levels = new List<GameObject>();
    public GameObject levelStartMenu, gameOverMenu, finishGameMenu;
    public bool gameActive = false;
    public GameObject cam;
    public GameObject calendar;
    public GameObject moneyIcons;

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
        
    }

    
    void Update()
    {
        
    }

    public void NextLevel()
    {
        UpdateMoney();
        moneyIcons.SetActive(true);
        StartCoroutine(IconMove());
        //StartCoroutine(LoadNextLevel());

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
        gameActive = true;
        PlayerController.Currrent.playButton.SetActive(false);
        PlayerController.Currrent.follower.follow = true;
        cam.GetComponent<SplineFollower>().follow = true;
        calendar.GetComponent<SplineFollower>().follow = true;
        calendar.transform.DOScale(1, 0.2f).SetEase(Ease.Linear);
    }

    public void UpdateMoney()
    {


        PriceGenerator.Current.totalPriceTextBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PriceGenerator.Current.price.ToString();
    }

    

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(5f);

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
}
