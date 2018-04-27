using UnityEngine;
using System.Collections.Generic;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speedJump;
    [SerializeField]
    private GameObject head;
    [SerializeField]
    private GameObject body;
    [SerializeField]
    private float friction;
    [SerializeField]
    private AudioClip[] audioClips;
    [SerializeField]
    private int timeAudio;

    private Rigidbody rb;
    private AudioSource audioBip;
    private float angleLook;
    private int indexAudio = 0;
    private Camera mainCamera;
    private bool jumping = false;
    private List<string> listKey;
    private int countMap = 0;
    private GameScript gameScript;
    private bool gamePaused = false;
    private GameObject menuGameOver;
    

    void Start()
    {
        listKey = new List<string>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();       
        audioBip = GetComponent<AudioSource>();  
        gameScript = (GameScript)GameObject.Find("Information").gameObject.GetComponent(typeof(GameScript));
        menuGameOver = GameObject.Find("MenuGameOverCanvas").gameObject;
        menuGameOver.SetActive(false);
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        if(!jumping)
        {
            jumping = true;
            jump = jump * speedJump;
        }
        else
        {
            jump = 0;
        }
        
        Vector3 movement = Quaternion.AngleAxis(mainCamera.transform.eulerAngles.y, Vector3.up) * new Vector3(moveHorizontal * speed, jump, moveVertical * speed);

        if(moveVertical!=0.0 || moveHorizontal!=0.0)
        {
            angleLook = angleLook*(float)0.9+getAngle(movement.x, movement.z) * (float)0.1;
        }

        if(Time.time % timeAudio == 0)
        {
            audioBip.clip = audioClips[indexAudio];
            audioBip.Play();
            indexAudio++;
            if(indexAudio>=audioClips.Length)
            {
                indexAudio = 0;
            }
        }

        rb.AddForce(movement);
        rb.AddForce(-friction * rb.velocity);
    }

    void Update()
    {      
        head.transform.eulerAngles = new Vector3(-90, 0, angleLook);     
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Map_Collectable")
        {
            countMap++;
            gameScript.setCountMap(countMap);
            Destroy(other.gameObject);
        }     
        if(other.tag=="Key")
        {
            KeyScript key = (KeyScript)other.GetComponent(typeof(KeyScript));
            listKey.Add(key.getColor());
            gameScript.setKey(listKey);
            Destroy(other.gameObject);
        }
        if(other.tag=="Laser" || other.tag =="Spikes")
        {
            //TODO
            
            Time.timeScale = 0;
            menuGameOver.SetActive(true);
            Debug.Log("Dead");
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Floor")
        {
            jumping = false;
        }
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

    public bool hasKey(string color)
    {
        return listKey.Contains(color);
    }
}
