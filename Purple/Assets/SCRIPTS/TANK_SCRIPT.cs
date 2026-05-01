using UnityEngine;

public class TANK_SCRIPT : MonoBehaviour
{

    public bool forward;
    public bool back;
    public bool left;
    public bool right;

    public bool shoot;
    public bool jump;
    public bool ground;

    public GameObject barrel;
    public GameObject Bullet;
    public GameObject Body;

    public Color Bullet_COLOR;

    public float UP_VEL;
    public float height;
    public float fall_speed = 1;
    public float fall_mult;
    private float new_fall_speed;
    public Vector3 SIDEWAYS_VEL;

    public LayerMask OBJECTS;

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

        ground_check();
    }

    private void FixedUpdate()
    {
        if (jump && ground)
        {
            UP_VEL = 5;
        }

        Vector3 moving = new Vector3(0, UP_VEL, 0);
        transform.position += moving * Time.fixedDeltaTime;

        if (ground == false)
        {
            UP_VEL -= new_fall_speed * Time.fixedDeltaTime;
            new_fall_speed += Time.deltaTime * fall_mult;
        }

        if (ground == true)
        {
            new_fall_speed = fall_speed;
        }
    }

    void ground_check()
    {
        RaycastHit hit;
        ground = false;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, OBJECTS))
        {
            if (hit.distance <= height)
            {
                Debug.Log(hit.distance);
                ground = true;
                UP_VEL = 0;
            }
        }
    }
}
