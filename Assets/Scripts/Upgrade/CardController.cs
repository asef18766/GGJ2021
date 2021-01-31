using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using MainGame.Player;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    private GameObject[] cards = new GameObject[3];
    [SerializeField] private GameObject[] cardChoices = new GameObject[5];
    [SerializeField] private GameObject canvas;
    [SerializeField] private PlayerProp playerProp;
    [SerializeField] private Button sureButton;

    // Start is called before the first frame update
    void Start()
    {
        ShowCards();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCards()
    {
        var rnd = new System.Random();
        var randomNumbers = Enumerable.Range(0, cardChoices.Length).OrderBy(x => rnd.Next()).Take(3).ToList();
        for (int i = 0; i < 3; i++)
        {
            cards[i] = cardChoices[randomNumbers[i]];
            ((RectTransform)cards[i].transform).localPosition = new Vector3(-500 + i * 500, 0, 0);
        }
        sureButton.interactable = true;
    }

    public void ApplyCard()
    {
        for (int i = 0; i < 3; i++)
        {
            Card card = cards[i].GetComponent<Card>();
            if (card.selected)
            {
                playerProp.atk += card.attack;
                playerProp.maxHealth += card.health;
                playerProp.mvSpeed = (int)(playerProp.mvSpeed * card.speed);
            }

            playerProp.reputation += card.reputation * (card.selected ? -1 : 1);
            card.selected = false;

            ((RectTransform)card.transform).localPosition = new Vector3(-1500, 0, 0);
        }

        sureButton.interactable = false;
        GameObject.Find("SceneController").GetComponent<SceneController>().ChangeScene("ModeAndMapTest");
    }
}
