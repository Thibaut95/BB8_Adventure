using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    [SerializeField]
    private float speedRotation;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        this.transform.Rotate(new Vector3(0, speedRotation*Time.deltaTime, 0), Space.World);

        
        

        

        //this.transform.RotateAround(this.transform.position - new Vector3(-1, 0, -1),new Vector3(0,1,0),speedRotation);
    }
}
