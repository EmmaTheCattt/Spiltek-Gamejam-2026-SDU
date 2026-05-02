using UnityEngine;
using UnityEngine.SceneManagement;

public class PAINTING_TRANSPORT : MonoBehaviour
{
    public string SCENE_TRANFER;

    public void transport()
    {
        SceneManager.LoadScene(SCENE_TRANFER);
    }
}
