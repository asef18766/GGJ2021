using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public string name;
    public int attack;
    public int health;
    public double speed;
    public int reputation;
    public string description;
    public CardController controller = null;
    // Start is called before the first frame update
    void Start()
    {
        //if (transform.position.y < 500) return;
        Debug.Log(((RectTransform)transform).localPosition);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.ApplyCard(this);
    }
}
