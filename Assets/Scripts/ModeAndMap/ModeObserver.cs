using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeObserver : MonoBehaviour
{
    [SerializeField] private Modes currentMode = Modes.Normal;

    public Collider2D collider;
    public Renderer renderer;

    [SerializeField]
    public List<ModeConditions> modeConditions = new List<ModeConditions>();

    private void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
        renderer = gameObject.GetComponent<Renderer>();
        ModeControl.Instance.RegisterObserver(this);
    }

    public void OnNotify(Modes updateMode)
    {
        currentMode = updateMode;
        DoModeActions(currentMode);
    }

    public void DoModeActions(Modes currentMode)
    {
        ModeConditions targetCondition = new ModeConditions();

        //取得條件
        bool conditionFound = false;
        foreach (var condition in modeConditions)
        {
            if(condition.mode == currentMode)
            {
                targetCondition = condition;
                conditionFound = true;
            }
        }
        if (!conditionFound) { Debug.LogError("沒找到ModeConditions"); }
        // 做動作
        if(renderer!=null)
        {
            renderer.enabled = targetCondition.CanShow;
            renderer.sharedMaterial = targetCondition.material;
        }
        if(collider!=null)
        {
            collider.enabled = targetCondition.CanCollide;
        }

    }

 
}


