using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Dreamteck.Splines;

public class LevelController : MonoBehaviour
{
    public static LevelController Current;
    public List<GameObject> levels = new List<GameObject>();
    public GameObject gameOverMenu, finishGameMenu;
    public bool gameActive = false;
    public GameObject cam;

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

    public void StartLevel()
    {
        gameActive = true;
        PlayerController.Currrent.playButton.SetActive(false);
        PlayerController.Currrent.follower.follow = true;
        cam.GetComponent<SplineFollower>().follow = true;
    }
}
