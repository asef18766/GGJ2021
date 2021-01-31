using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public static int level = 1;
    string prevScene="";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeScene(string sceneName)
    {
        prevScene = sceneName;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void ChangeLevelScene()
    {
        level++;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level"+ level.ToString());
    }


}
