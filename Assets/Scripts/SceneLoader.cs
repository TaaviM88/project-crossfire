using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public int  LevelIndex = 1;
        
    public void LoadGameScene()
    {
        //ladataan kenttä jonka index on build setting numerossa 1; Tässä tapauksessa Level1.
        SceneManager.LoadScene(LevelIndex);
    }
}
