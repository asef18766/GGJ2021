using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainGame.Player;

public class Health : MonoBehaviour
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
        float ratio = (float)curPlayerProp.curHealth / curPlayerProp.maxHealth;
        float width = ((RectTransform)transform).rect.width;
        transform.localPosition = new Vector3(-width * (0.5f - ratio / 2), 0, 0);
        transform.localScale = new Vector3(ratio, 1, 1);
    }
}
