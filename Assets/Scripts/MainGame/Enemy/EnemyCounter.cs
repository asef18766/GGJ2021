using MainGame.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter Instance;

    public List<GameObject> enemyGobjs = new List<GameObject>();
    public List<IEnemy> allEnemies = new List<IEnemy>();

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        foreach (var o in enemyGobjs)
        {
            allEnemies.Add(o.GetComponent<IEnemy>());
        }

        Debug.Log($"敵人數: {allEnemies.Count}");
    }

    public void RemoveEnemy(IEnemy e)
    {
        allEnemies.Remove(e);
        Debug.Log($"敵人數: {allEnemies.Count}");
        CounterCheck();
    }

    public void CounterCheck()
    {
        if(allEnemies.Count==0)
        {
            Debug.Log("關卡結束");
            SceneController.Instance.ChangeScene("upgrade");
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            SceneController.Instance.ChangeScene("upgrade");
        }

    }
}
