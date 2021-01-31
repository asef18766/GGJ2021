using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainGame.Player;

public class EndingController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject[] endings = new GameObject[3];
    [SerializeField] private GameObject[] images = new GameObject[3];
    [SerializeField] private PlayerProp playerProp;
    // Start is called before the first frame update
    void Start()
    {
        int index;
        if (playerProp.reputation < -100)
            index = 0;
        else if (playerProp.reputation < 100)
            index = 1;
        else
            index = 2;

        ((RectTransform)endings[index].transform).localPosition = new Vector3(120, -580, 0);
        ((RectTransform)images[index].transform).localPosition = new Vector3(0, 0, 0);
    }

    public void ChangeSceneBackToMenu()
    {
        SceneController.Instance.ChangeScene("menu");
    }
}
