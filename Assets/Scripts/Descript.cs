using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descript : MonoBehaviour
{
    public void ChangeSceneToGame()
    {
        SceneController.Instance.ChangeScene("ModeAndMapTest");
    }
}
