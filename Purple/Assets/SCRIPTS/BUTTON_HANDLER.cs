using UnityEngine;
using UnityEngine.SceneManagement;

public class BUTTON_HANDLER : MonoBehaviour
{
    public const string LEVEL1 = "LEVEL_1";
    public void STARTBUTTON()
    {
        SceneManager.LoadScene("LEVEL_1");
    }
}
