using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float sensivity = 10;
    float x_move;
    float z_move;
    float x_rot;
    float y_rot;
    Vector3 move_Direction_x;
    Vector3 move_Direction_z;
    public  Animator animator;
    public float speed;
    public Camera player_camera;
    public Transform hands;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player_camera.GetComponent<Shooting>().IsShooting == true)
        {
            animator.SetBool("Shot", true);
        }
        else
        {
            animator.SetBool("Shot", false);
        }
        if (player_camera.GetComponent<Shooting>().IsReloading == true)
        {
            animator.SetBool("Reload", true);
        }
        else
        {
            animator.SetBool("Reload", false);
        }

    }


    void Move()
    {
        
        x_move = Input.GetAxis("Horizontal");
        z_move = Input.GetAxis("Vertical");
        move_Direction_z = transform.forward*z_move;
        if (z_move != 0)
        {
            animator.SetBool("Walk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += (move_Direction_x + move_Direction_z) * speed * Time.deltaTime * 1.5f;
            }
            else
            {
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }
          
        move_Direction_x = transform.right*x_move;
        transform.position += (move_Direction_x+move_Direction_z)*speed*Time.deltaTime;       
        Rotation();


    }
    void Rotation()
    {

        x_rot += Input.GetAxis("Mouse X")*sensivity * Time.deltaTime;
        y_rot += Input.GetAxis("Mouse Y")*sensivity * Time.deltaTime;
        y_rot = Mathf.Clamp(y_rot, -90, 90);
        player_camera.transform.rotation = Quaternion.Euler(-y_rot, x_rot, 0f);
        hands.rotation = player_camera.transform.rotation;
        transform.rotation = Quaternion.Euler(0f,x_rot, 0f);
    }
    private void FixedUpdate()
    {
        Move();
        
    }

}
