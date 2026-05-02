using TMPro.Examples;
using UnityEngine;
using TMPro;

public class CHANGE_SCORE : TEXT
{

    // Update is called once per frame
    void Update()
    {
        TEXT_text.text = "Painted Tiles: " + GAMEMANAGER.GM.score + "/" + GAMEMANAGER.GM.Max_score;
        check_score();

        if (GAMEMANAGER.GM.Max_score <= GAMEMANAGER.GM.score)
        {
            CONGRATS.SetActive(true);
        }
    }
}
