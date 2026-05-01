using UnityEngine;

public class Cam : MonoBehaviour
{

    public float SensX;
    public float SensY;

    public float rotationX;
    public float rotationY;

    public float High_clamp;
    public float Low_clamp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -Low_clamp, High_clamp);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        //Target_direction.transform.rotation = quaternion.Euler(rotationX, rotationY, 0);
    }


}
