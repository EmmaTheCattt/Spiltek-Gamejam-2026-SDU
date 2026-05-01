using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER GM;

    public int score = 0;
    public int Max_score;
    public float Max_time;

    public int Max_score_Level_1;
    public float Max_time_Level_1;

    public int Max_score_level_2;

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
        if (SceneManager.GetActiveScene().name == "LEVEL_1")
        {
            Max_score = Max_score_Level_1;
            Max_time = Max_time_Level_1;
        }
    }
}
