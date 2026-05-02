using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER GM;

    public int score = 0;
    public int Max_score;

    public float Current_time;
    public float Max_time;

    public bool[] cleared;

    [Header("LEVEL 1")]
    public int Max_score_Level_1;
    public float Max_time_Level_1;

    [Header("LEVEL 2")]
    public int Max_score_Level_2;
    public float Max_time_Level_2;

    [Header("LEVEL 3")]
    public int Max_score_Level_3;
    public float Max_time_Level_3;

    [Header("LOADED?")]
    public bool loaded = false;

    void Awake()
    {
        if (GM != null && GM != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GM = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL_1" && loaded == false)
        {
            Max_score = Max_score_Level_1;
            Current_time = Max_time_Level_1;
            Max_time = Max_time_Level_1;
            loaded = true;
        }

        if (SceneManager.GetActiveScene().name == "LEVEL_2" && loaded == false)
        {
            Max_score = Max_score_Level_2;
            Current_time = Max_time_Level_2;
            Max_time = Max_time_Level_2;
            loaded = true;
        }

        if (SceneManager.GetActiveScene().name == "LEVEL_3" && loaded == false)
        {
            Max_score = Max_score_Level_3;
            Current_time = Max_time_Level_3;
            Max_time = Max_time_Level_3;
            loaded = true;
        }

        if (SceneManager.GetActiveScene().name != "TITLE")
        {
            check_input();
        }
    }

    void check_input()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Max_score <= score)
            {
                for(int i = 0; i < cleared.Length; i++)
                {
                    if (cleared[i] == false)
                    {
                        cleared[i] = true;
                        loaded = false;
                        SceneManager.LoadScene("TITLE");
                        break;
                    }
                }
            }
        }
    }
}
