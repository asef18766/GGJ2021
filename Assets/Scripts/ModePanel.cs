using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModePanel : MonoBehaviour
{
    public Sprite[] sprites;

    public Image image;
    public Image light;

    Modes m = Modes.Normal;

    private void Awake()
    {
        image.enabled = false;
        light.enabled = false;
    }

    void Update()
    {
        if (m == ModeControl.Instance.currentMode) return;

        m = ModeControl.Instance.currentMode;

        if (m == Modes.Normal)
        {
            image.enabled = false;
            light.enabled = false;
        }
        else if (m== Modes.Found)
        {
            image.sprite = sprites[0];
            image.enabled = true;
            light.enabled = true;
        }
        else if (m == Modes.Lost)
        {
            image.sprite = sprites[1];
            image.enabled = true;
            light.enabled = true;
        }


    }



}
