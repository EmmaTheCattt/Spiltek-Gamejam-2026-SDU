using UnityEngine;

public class TANK_SCRIPT : MonoBehaviour
{

    public bool forward;
    public bool back;
    public bool left;
    public bool right;

    public bool shoot;
    public bool jump;
    public bool ground = true;

    public GameObject barrel;
    public GameObject Bullet;
    public GameObject Body;

    public Color Bullet_COLOR;

    public float UP_VEL;
    public float height;
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
        if (jump || ground)
        {
            UP_VEL = 5;
        }

        Vector3 moving = new Vector3(0, UP_VEL, 0);
        transform.position += moving * Time.fixedDeltaTime;

        if (ground == false)
        {
            UP_VEL -= Time.fixedDeltaTime;
        }
    }

    void ground_check()
    {
        RaycastHit hit;
        ground = false;

        if (Physics.Raycast(transform.position, Vector3.down * height, out hit, OBJECTS))
        {
            ground = true;
        }
    }
}
