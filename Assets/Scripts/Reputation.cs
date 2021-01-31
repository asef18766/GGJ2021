using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainGame.Player;

public class Reputation : MonoBehaviour
{
    [SerializeField] private PlayerProp playerProp;
    [SerializeField] private PlayerProp curPlayerProp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float ratio = (float)curPlayerProp.reputation / 300;
        float width = ((RectTransform)transform).rect.width;
        transform.localPosition = new Vector3(width * ratio / 4, 0, 0);
        transform.localScale = new Vector3(Mathf.Abs(ratio) / 2, 1, 1);
    }
}
