using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEditor;

public class TOGGLE_SWITCH : MonoBehaviour, IPointerClickHandler
{
    public Slider SLIDE;
    public bool INFINITE = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SLIDE = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (INFINITE == false)
        {
            SLIDE.value = 0;
        }

        if (INFINITE == true)
        {
            SLIDE.value = 1;
        }

        GAMEMANAGER.GM.infinite = INFINITE;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        INFINITE = !INFINITE;
    }
}
