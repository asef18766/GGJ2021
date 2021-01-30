using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
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
}
