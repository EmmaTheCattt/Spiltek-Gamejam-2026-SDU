using UnityEngine;

public class QUICK_T : TEXT
{
    // Update is called once per frame
    void Update()
    {
        if (GAMEMANAGER.GM.Current_time <= 0)
        {
            TEXT_text.text = "You ran out of time... Press Right click to try again";
        }
    }
}
