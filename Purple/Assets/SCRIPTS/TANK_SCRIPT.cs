using UnityEngine;

public class TANK_SCRIPT : MonoBehaviour
{

    public bool forward;
    public bool back;
    public bool left;
    public bool right;

    public bool shoot;
    public bool jump;

    public GameObject barrel;
    public GameObject Bullet;

    public Color Bullet_COLOR;
    public Rigidbody RB;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        back = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        shoot = Input.GetMouseButtonDown(0);
        jump = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        
    }
}
