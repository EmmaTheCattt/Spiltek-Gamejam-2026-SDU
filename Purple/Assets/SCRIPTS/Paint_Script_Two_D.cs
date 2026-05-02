using UnityEngine;

public class Paint_Script_Two_D : MonoBehaviour
{
    public bool purple;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        purple = false;  
    }

    // Update is called once per frame
    void Update()
    {
        PaintCheck();
    }
    private void PaintCheck()
    {
        if (purple)
        {
            GetComponent<Renderer>().material.color = new Color(0.6033876f, 0.119912f, 0.8867924f);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            purple = true;
        }
    }
}
