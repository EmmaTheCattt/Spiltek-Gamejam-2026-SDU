using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BUTTON_HANDLER : MonoBehaviour
{

    public GameObject[] buttons;
    public Image[] BUT_IMG;

    private void Update()
    {
        if (GAMEMANAGER.GM.cleared[0] == true)
        {
            buttons[0].GetComponent<Button>().enabled = true;
            BUT_IMG[0].color = Color.purple;
            buttons[1].GetComponent<Button>().enabled = true;
            BUT_IMG[1].color = Color.white;
        }

        for (int i = 1; i < buttons.Length; i++)
        {
            if (GAMEMANAGER.GM.cleared[i - 1] == true)
            {
                buttons[i].GetComponent<Button>().enabled = true;
                BUT_IMG[i].color = Color.white;
            }

            if (GAMEMANAGER.GM.cleared[i] == true)
            {
                buttons[i].GetComponent<Button>().enabled = true;
                BUT_IMG[i].color = Color.purple;

                if ((i + 1)! > buttons.Length)
                {
                    buttons[i + 1].GetComponent<Button>().enabled = true;
                    BUT_IMG[i + 1].color = Color.white;
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
