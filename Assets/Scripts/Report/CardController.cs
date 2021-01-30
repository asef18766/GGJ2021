using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private GameObject[] cards = new GameObject[3];
    public GameObject card;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            cards[i] = Instantiate(card, canvas.transform);
            ((RectTransform)cards[i].transform).localPosition = new Vector3(-200 + i * 200, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
