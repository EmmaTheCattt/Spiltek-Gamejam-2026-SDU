using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class TOGGLE_SWITCH : MonoBehaviour
{
    public Toggle AHHHH;
    public bool INFINITE = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        INFINITE = GAMEMANAGER.GM.infinite;
        AHHHH.isOn = INFINITE;
    }

    // Update is called once per frame
    void Update()
    {
        INFINITE = AHHHH.isOn;
        GAMEMANAGER.GM.infinite = INFINITE;
    }
}
