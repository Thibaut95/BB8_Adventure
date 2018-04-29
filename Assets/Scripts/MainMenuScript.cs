using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    private int levelSelected = 0;

    //Ouput the new value of the Dropdown into Text
    public void DropdownValueChanged(Dropdown change)
    {
        levelSelected = change.value;
    }

    public void startGame()
    {
        SceneManager.LoadScene("Level" + (levelSelected + 1));
    }
}
