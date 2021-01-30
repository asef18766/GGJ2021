using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int attack;
    public int health;
    public double speed;
    public int reputation;
    public string description;
    public bool selected = false;
    [SerializeField] private CardController controller;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = itemName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selected = !selected;
        string show = selected ? "√" : "";
        GetComponent<Text>().text = show + itemName + show;
    }
}
