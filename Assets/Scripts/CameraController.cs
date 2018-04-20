using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float turnSpeed = 1.0f;
    //private Vector3 offset;
    private Vector3 offsetX;
    private Vector3 offsetY;

    [SerializeField]
    private int distance;
    [SerializeField]
    private int height;

    private float angleY=0;

    // Use this for initialization
    void Start ()
    {
        //offset = transform.position - player.transform.position;
        offsetX = new Vector3(0, height, -distance);
        offsetY = new Vector3(0, 0, -distance);
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetX;
        //offsetY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.up) * offsetY; 
        angleY += Input.GetAxis("Mouse Y");
        transform.position = player.transform.position + offsetX - new Vector3(0, angleY, 0);
        transform.LookAt(player.transform.position+new Vector3(0, angleY, 0));
        
    }
}
