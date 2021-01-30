using MainGame.Enemy;
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

        // Actually not a good implementation, but we'll use this for now :p
        DoModeActions(currentMode);
        DoEnemyConditions(currentMode);
    }

    public void DoModeActions(Modes currentMode)
    {
        // 根據模式 開關碰撞框、隱藏
        ModeConditions targetCondition = new ModeConditions();

        //取得模式條件
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

    IHideable ihideable;
    Modes previousMode = Modes.Normal;
    bool IsFirstTime = true;
    public void DoEnemyConditions(Modes currentMode)
    {
        // 敵人特例，控制模式下的移動
        ihideable = this.gameObject.GetComponent<IHideable>();
        if (ihideable == null) return; // 不是敵人
        

        if(currentMode == Modes.Lost)
        {
            previousMode = Modes.Lost;
            ihideable.SwitchLost();
            return;
        }
        if (currentMode == Modes.Found)
        {
            previousMode = Modes.Found;
            ihideable.SwitchFound();
            return;
        }
        if(currentMode == Modes.Normal)
        {
            if(previousMode == Modes.Found)
            {
                ihideable.SwitchFound(); //開關，再呼叫一次回復正常
            }
            if (previousMode == Modes.Lost)
            {
                ihideable.SwitchLost();
            }
            previousMode = Modes.Normal;
        }

        // 很蠢，但可以處理FoundEnemy初始化的問題
        // 一開始就enable=false的物件 ModeObserver就沒有註冊到ModeControl(Subject)
        // 第一次 enable=true -> SwitchFound -> enable=false
        if(IsFirstTime)
        {
            ihideable.SwitchFound();
            IsFirstTime = false;
        }

    }

 
}


