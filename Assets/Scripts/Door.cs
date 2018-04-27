using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private GameObject door;
    private Vector3 posClose;
    private Vector3 posOpen;
    private GameObject player;
    private PlayerControler playerControler;

    [SerializeField]
    private float offset;
    [SerializeField]
    private float speed;
    [SerializeField]
    private string color;

   

	// Use this for initialization
	void Start ()
    {
        player =    GameObject.Find("BB8").gameObject;
        door = this.transform.Find("door").gameObject;
        posClose = door.transform.position;
        posOpen = posClose + new Vector3(0, offset, 0);
        playerControler = (PlayerControler)player.GetComponent(typeof(PlayerControler));      
    }
	
	// Update is called once per frame
	void Update ()
    {    
         if ((player.transform.position - this.transform.position).sqrMagnitude < 20 && playerControler.hasKey(color))      
         {
            if (posOpen.y > door.transform.position.y)
            {
                door.transform.Translate(new Vector3(0, 0, speed));
            }
         }
         else
         {
             if(posClose.y < door.transform.position.y)
             {
                 door.transform.Translate(new Vector3(0, 0, -speed));
             }
         }
    }
}
