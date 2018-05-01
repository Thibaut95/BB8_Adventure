using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class MenuFinished : MonoBehaviour {

    [SerializeField]
    private float penality;

    private string saveFile = "/Save/";
    BestScore bestScore;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        this.transform.Find("NewBestScore").gameObject.SetActive(false);
        this.transform.Find("BestScoreArea").gameObject.SetActive(false);
        GameScript gameScript= (GameScript)GameObject.Find("Information").gameObject.GetComponent(typeof(GameScript));

        float time = gameScript.getTime();
        int map = gameScript.getMap();
        int maxMap = gameScript.getMaxMap();
        float penalityTotal = (maxMap - map) * penality;
        float finalTime = time + penalityTotal;

        this.transform.Find("TextTime").gameObject.GetComponent<Text>().text = time.ToString("0.00");
        this.transform.Find("TextMap").gameObject.GetComponent<Text>().text = map + "/"+ maxMap;
        this.transform.Find("TextPenality").gameObject.GetComponent<Text>().text = penalityTotal.ToString("0.00");
        this.transform.Find("TextFinalTime").gameObject.GetComponent<Text>().text = finalTime.ToString("0.00");

        string filePath = Application.dataPath + saveFile + SceneManager.GetActiveScene().name;
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            bestScore = BestScore.CreateFromJSON(dataAsJson);
            if(bestScore.time<finalTime)
            {
                GameObject bestscoreGO = this.transform.Find("BestScoreArea").gameObject;
                bestscoreGO.SetActive(true);
                bestscoreGO.transform.Find("TextName").gameObject.GetComponent<Text>().text = bestScore.namePlayer;
                bestscoreGO.transform.Find("TextBestTime").gameObject.GetComponent<Text>().text = bestScore.time.ToString("0.00");

            }
            else
            {
                bestScore.time = finalTime;
                this.transform.Find("NewBestScore").gameObject.SetActive(true);
            }
        }
        else
        {
            bestScore = new BestScore();
            bestScore.time = finalTime;
            this.transform.Find("NewBestScore").gameObject.SetActive(true);
        }
    }

    public void okPressed(Text value)
    {
        bestScore.namePlayer = value.text;
        string dataAsJson = JsonUtility.ToJson(bestScore);

        string filePath = Application.dataPath +saveFile+ SceneManager.GetActiveScene().name;
        File.WriteAllText(filePath, dataAsJson);
        
    }
}
