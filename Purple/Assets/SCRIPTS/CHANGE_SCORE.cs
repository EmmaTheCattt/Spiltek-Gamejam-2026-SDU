using TMPro.Examples;
using UnityEngine;
using TMPro;

public class CHANGE_SCORE : MonoBehaviour
{
    public TextMeshProUGUI TEXT;

    // Update is called once per frame
    void Update()
    {
        TEXT.text = "Painted Tiles: " + GAMEMANAGER.GM.score + "/" + GAMEMANAGER.GM.Max_score;

        if (GAMEMANAGER.GM.score >= GAMEMANAGER.GM.Max_score)
        {
            TEXT.color = Color.purple;
        }
        else
        {
            TEXT.color = Color.white;
        }
    }
}
