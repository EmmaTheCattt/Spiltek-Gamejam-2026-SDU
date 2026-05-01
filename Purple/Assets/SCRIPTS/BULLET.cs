using UnityEngine;

public class BULLET : MonoBehaviour
{

    public float speed;

    public Vector3 Direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * speed * Time.deltaTime;

        speed -= Time.deltaTime;
    }
}
