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
    public float speed;
    public float Max_Y_pos_fall;
    private float new_fall_speed;

    public Vector3 SIDEWAYS_VEL;
    public Vector3 BUL_DIR;
    public Vector3 SPAWN;

    public LayerMask OBJECTS;

    public bool isMoving;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SPAWN = transform.position;
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

        BUL_DIR = new Vector3(barrel.transform.position.x - transform.position.x, barrel.transform.position.y - transform.position.y, barrel.transform.position.z - transform.position.z).normalized;

        ground_check();
        calculateIsMoving();
        
        if (shoot)
        {

            BUL_DIR = new Vector3(barrel.transform.position.x - transform.position.x, barrel.transform.position.y - transform.position.y, barrel.transform.position.z - transform.position.z).normalized;

            GameObject bullet = Instantiate(Bullet, barrel.transform.position, Quaternion.identity);

            bullet.GetComponent<BULLET>().Direction = BUL_DIR;
            
            Debug.Log(BUL_DIR);
        }

        if (transform.position.y < Max_Y_pos_fall)
        {
            UP_VEL = 0;
            SIDEWAYS_VEL = Vector3.zero;
            ground = true;
            transform.position = SPAWN;
        }
    }

    public void calculateIsMoving()
    {
        if (forward || left || right || back)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        if (jump && ground)
        {
            UP_VEL = 5;
        }

        if (forward)
        {
            SIDEWAYS_VEL = new Vector3(barrel.transform.position.x - transform.position.x, 0, barrel.transform.position.z - transform.position.z);
            SIDEWAYS_VEL = SIDEWAYS_VEL.normalized;
            SIDEWAYS_VEL = SIDEWAYS_VEL * speed;
        }

        if (back)
        {
            SIDEWAYS_VEL = new Vector3(barrel.transform.position.x - transform.position.x, 0, barrel.transform.position.z - transform.position.z);
            SIDEWAYS_VEL = SIDEWAYS_VEL.normalized;
            SIDEWAYS_VEL = SIDEWAYS_VEL * -speed;
        }

        Vector3 moving = new Vector3(0, UP_VEL, 0);
        transform.position += (moving * Time.fixedDeltaTime) + (SIDEWAYS_VEL * Time.deltaTime);

        if (ground == false)
        {
            UP_VEL -= new_fall_speed * Time.fixedDeltaTime;
            new_fall_speed += Time.deltaTime * fall_mult;
        }

        if (ground == true)
        {
            new_fall_speed = fall_speed;
            SIDEWAYS_VEL = Vector3.zero;
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
