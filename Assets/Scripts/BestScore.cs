using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BestScore {

    public string namePlayer;
    public float time;

    public static BestScore CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<BestScore>(jsonString);
    }

}
