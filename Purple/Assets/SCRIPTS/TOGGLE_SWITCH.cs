using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class TOGGLE_SWITCH : MonoBehaviour, IPointerClickHandler
{
    public Slider AHHHH;
    public bool INFINITE = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (INFINITE)
        {
            AHHHH.value = 1;
        }

        if (!INFINITE)
        {
            AHHHH.value = 0;
        }

        GAMEMANAGER.GM.infinite = INFINITE;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        INFINITE = !INFINITE;
    }
}
