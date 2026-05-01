using UnityEngine;
using TMPro;

public class TEXT : MonoBehaviour
{
    public TextMeshProUGUI TEXT_text;

    public void check_score()
    {
        if (GAMEMANAGER.GM.score >= GAMEMANAGER.GM.Max_score)
        {
            TEXT_text.color = Color.purple;
        }
        else
        {
            TEXT_text.color = Color.white;
        }
    }
}
