using UnityEngine;

public class BULLET : MonoBehaviour
{

    public float speed;

    public Vector3 Direction;

    public GameObject blasto_rado;

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

    private void OnCollisionEnter(Collision collision)
    {
        blasto_rado.SetActive(true);

        Invoke("DestroyMe", 0.05f);
    }

    private void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
