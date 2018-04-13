using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMOve : MonoBehaviour {

    private Vector3 posEnd;
    private Vector3 posStart;
    private Vector3 vector;
    private float percent;
    private bool direction = true;

    [SerializeField]
    private float speed;

	// Use this for initialization
	void Start ()
    {
        posStart = this.transform.position;
        posEnd = this.transform.Find("End").position;
        vector = posEnd - posStart;
        percent = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = posStart + vector * percent;
        if(direction)
        {
            percent += (float)speed;
        }
        else
        {
            percent -= (float)speed;
        }
        if(percent>=1)
        {
            direction = false;
        }
        else if(percent<=0)
        {
            direction = true;
        }
	}
}
