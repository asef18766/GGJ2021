using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using MainGame.Player;

public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject[] cards = new GameObject[3];
    [SerializeField] private GameObject[] cardChoices = new GameObject[5];
    [SerializeField] private GameObject canvas;
    [SerializeField] private PlayerProp playerProp;

    // Start is called before the first frame update
    void Start()
    {
        var rnd = new System.Random();
        var randomNumbers = Enumerable.Range(0, cardChoices.Length).OrderBy(x => rnd.Next()).Take(3).ToList();
        Debug.Log(randomNumbers);
        for (int i = 0; i < 3; i++)
        {
            cards[i] = Instantiate(cardChoices[randomNumbers[i]], canvas.transform);
            Text card = cards[i].GetComponent<Text>();
            card.text = cards[i].GetComponent<Card>().name;
            card.rectTransform.localPosition = new Vector3(-200 + i * 200, 0, 0);
            cards[i].GetComponent<Card>().controller = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyCard(Card card)
    {
        Debug.Log(card.name);
        playerProp.atk += card.attack;
        playerProp.maxHealth += card.health;
        playerProp.mvSpeed = (int)(playerProp.mvSpeed * card.speed);
        playerProp.reputation += card.reputation;

        for (int i = 0; i < 3; i++)
        {
            Destroy(cards[i]);
        }
    }
}
