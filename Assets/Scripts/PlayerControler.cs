using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speedJump;
    [SerializeField]
    private GameObject head;

    private Rigidbody rb;
    private Rigidbody rbHead;
    private float angleLook;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbHead = head.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        if(rb.velocity.y==0)
        {
            jump = jump * speedJump;
        }
        else
        {
            jump = 0;
        }
        
        Vector3 movement = new Vector3(moveHorizontal * speed, jump ,moveVertical * speed);

        if(moveVertical!=0.0 || moveHorizontal!=0.0)
        {
            angleLook = angleLook*(float)0.9+getAngle(moveHorizontal, moveVertical) * (float)0.1;
        }
        
        rb.AddForce(movement);
    }

    void Update()
    {
        head.transform.position = this.transform.position;
        head.transform.eulerAngles = new Vector3(-90, 0, angleLook);
    }
	
    float getAngle(float horizontal, float vertical)
    {
        float angle;
        if (horizontal == 0.0)
        {
            if (vertical < 0.0)
            {
                angle = 90;
            }
            else
            {
                angle = 270;
            }
        }
        else
        {
            angle = Mathf.Atan(vertical / horizontal);
            angle = angle * Mathf.Rad2Deg;
        }

        if (vertical == 0.0 && horizontal < 0.0)
        {
            angle += 180;
        }

        if (horizontal != 0.0 && vertical > 0.0)
        {
            angle += 270;
        }
        else if (horizontal < 0.0 && vertical < 0.0)
        {
            angle += 90;
        }
        else if (horizontal > 0.0 && vertical < 0.0)
        {
            angle = 360 - angle;
        }
        return angle;
    }
}
