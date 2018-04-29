using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

    private GameObject textTime;
    private GameObject textMap;
    private GameObject textKey;

    private float startTime;
    private bool isRunning=false;

    [SerializeField]
    private int nbMap;
   

	// Use this for initialization
	void Start ()
    {
        
        textTime = this.transform.Find("Text_Time").gameObject;     
        textMap = this.transform.Find("Text_Map").gameObject;
        textKey = this.transform.Find("Text_Key").gameObject;
        setCountMap(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        float currentTime = 0;
        
        if(isRunning)
        {
            currentTime = Time.time - startTime;
        }
        textTime.GetComponent<Text>().text = currentTime.ToString("0.00");
    }

    public void setCountMap(int countMap)
    {
        textMap.GetComponent<Text>().text = countMap.ToString()+"/"+nbMap.ToString();
    }

    public void setKey(List<string> listKey)
    {
        string list = "";
        foreach (string key in listKey)
        {
            list += key + " ";
        }
        textKey.GetComponent<Text>().text = list;
    }

    public void startGameTime()
    {
        if(!isRunning)
        {
            startTime = Time.time;
        }
        isRunning = true;  
    }
}
