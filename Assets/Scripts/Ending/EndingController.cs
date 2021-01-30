using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainGame.Player;

public class EndingController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject[] endings = new GameObject[3];
    [SerializeField] private PlayerProp playerProp;
    // Start is called before the first frame update
    void Start()
    {
        GameObject ending;
        if (playerProp.reputation > 300)
            ending = endings[0];
        else if (playerProp.reputation > 100)
            ending = endings[1];
        else
            ending = endings[2];

        ((RectTransform)ending.transform).localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
