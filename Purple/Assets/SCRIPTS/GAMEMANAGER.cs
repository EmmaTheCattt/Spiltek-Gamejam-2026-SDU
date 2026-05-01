using TMPro.Examples;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER GM;

    public int score = 0;

    void Awake()
    {
        if (GM != null && GM != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GM = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
