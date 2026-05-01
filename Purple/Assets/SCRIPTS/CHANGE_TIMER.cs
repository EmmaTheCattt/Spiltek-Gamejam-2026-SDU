using UnityEngine;

public class CHANGE_TIMER : TEXT
{

    public float time;

    public void Start()
    {
        time = GAMEMANAGER.GM.Max_time;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        TEXT.text = "TIME: " + ((int)time).ToString() + ((int)GAMEMANAGER.GM.Max_time).ToString();
    }
}
