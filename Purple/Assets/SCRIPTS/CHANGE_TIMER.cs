using UnityEngine;
using UnityEngine.SceneManagement;

public class CHANGE_TIMER : TEXT
{
    public int min;
    public int sec;

    // Update is called once per frame
    void Update()
    {
        if (GAMEMANAGER.GM.score < GAMEMANAGER.GM.Max_score)
        {
            GAMEMANAGER.GM.Current_time -= Time.deltaTime;
        }

        sec = (int)GAMEMANAGER.GM.Current_time % 60;

        min = (int)GAMEMANAGER.GM.Current_time / 60;

        if (sec < 10)
        {
            TEXT_text.text = "TIME: " + min.ToString() + ":0" + sec.ToString();
        }
        else
        {
            TEXT_text.text = "TIME: " + min.ToString() + ":" + sec.ToString();
        }
        check_score();


    }
}
