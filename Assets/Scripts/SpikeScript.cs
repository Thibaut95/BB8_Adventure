using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour {
    // Use this for initialization
    private Vector3 positionStart;
    private Vector3 positionEnd;
    private GameObject cone;
    private int direction;
    [SerializeField]
    private float delay;


    void Start () {
        cone = transform.Find("Cone").gameObject;
        positionEnd = cone.transform.position;
        positionStart = cone.transform.position - new Vector3(0,1.7f,0);
        cone.transform.position = positionStart;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (direction == 1)
        {   
            if(cone.transform.position.y < positionEnd.y)
            {
                cone.transform.position = cone.transform.position + new Vector3(0, 0.1f, 0);
            }
            else
            {
                direction = -1;
            }
        }else if (direction == -1)
        {
            if (cone.transform.position.y > positionStart.y)
            {
                cone.transform.position = cone.transform.position + new Vector3(0, -0.02f, 0);
            }
            else
            {
                direction = 0;
            }
        }
        
	}
    void OnCollisionEnter(Collision collision)
    {
        Invoke("SpikeUp", delay);
        
    }
    void SpikeUp()
    {
        direction = 1;
    }
}
