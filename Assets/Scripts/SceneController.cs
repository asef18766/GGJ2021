using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MainGame.Player;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public static int level = 1;
    string prevScene="";
    [SerializeField] private PlayerProp playerProp;
    [SerializeField] private PlayerProp curPlayerProp;

    void Awake()
    {
        Application.targetFrameRate = 60;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            curPlayerProp.Copy(playerProp);
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
        if (level>3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("ending");
            return;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level"+ level.ToString());

    }


}
