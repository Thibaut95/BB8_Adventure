using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");     
    }

    public void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }

}
