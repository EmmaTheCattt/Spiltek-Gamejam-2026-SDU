using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class BUTTON_HANDLER : MonoBehaviour
{

    public GameObject[] buttons;
    public Color[] BUT_IMG;

    private void Update()
    {
        if (GAMEMANAGER.GM.cleared[0] == true)
        {
            buttons[0].GetComponent<Button>().SetEnabled(true);
            BUT_IMG[0] = Color.purple;
            buttons[1].GetComponent<Button>().SetEnabled(true);
            BUT_IMG[1] = Color.white;
        }

        for (int i = 1; i < buttons.Length; i++)
        {
            if (GAMEMANAGER.GM.cleared[i - 1] == true)
            {
                buttons[i].GetComponent<Button>().SetEnabled(true);
                BUT_IMG[i] = Color.white;
            }

            if (GAMEMANAGER.GM.cleared[i] == true)
            {
                buttons[i].GetComponent<Button>().SetEnabled(true);
                BUT_IMG[i] = Color.purple;

                if ((i + 1)! > buttons.Length)
                {
                    buttons[i + 1].GetComponent<Button>().SetEnabled(true);
                    BUT_IMG[i + 1] = Color.white;
                }
            }
        }
    }

    public void LEVEL_1()
    {
        SceneManager.LoadScene("LEVEL_1");
    }

    public void LEVEL_2()
    {
        SceneManager.LoadScene("LEVEL_2");
    }

    public void LEVEL_3()
    {
        SceneManager.LoadScene("LEVEL_3");
    }

    public void LEVEL_4()
    {
        SceneManager.LoadScene("LEVEL_4");
    }

    public void LEVEL_5()
    {
        SceneManager.LoadScene("LEVEL_5");
    }
}
