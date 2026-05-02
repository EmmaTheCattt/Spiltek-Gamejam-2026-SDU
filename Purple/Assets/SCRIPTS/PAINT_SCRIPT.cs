using UnityEngine;

public class PAINT_SCRIPT : MonoBehaviour
{

    public Material PURPLE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("paintable"))
        {
            if (other.gameObject.GetComponent<Renderer>().sharedMaterial != PURPLE)
            {
                GAMEMANAGER.GM.score++;
                other.gameObject.GetComponent<MeshRenderer>().material = PURPLE;
            }
        }

        if (other.CompareTag("TARGET"))
        {
            if (other.gameObject.GetComponent<Renderer>().sharedMaterial != PURPLE)
            {
                GAMEMANAGER.GM.score += 1000;
                other.gameObject.GetComponent<MeshRenderer>().material = PURPLE;
            }
        }
    }
}
