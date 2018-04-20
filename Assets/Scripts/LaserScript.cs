using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField]
    private float time;

    

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("ToggleLaser", 0.0f, time);     
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void ToggleLaser()
    {
        this.transform.GetComponent<MeshRenderer>().enabled = !this.transform.GetComponent<MeshRenderer>().isVisible;
        this.transform.GetComponent<BoxCollider>().isTrigger = !this.transform.GetComponent<BoxCollider>().isTrigger;
        this.transform.GetComponent<BoxCollider>().enabled = !this.transform.GetComponent<BoxCollider>().enabled;
    }
}
