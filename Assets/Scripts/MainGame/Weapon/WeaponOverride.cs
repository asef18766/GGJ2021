using MainGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOverride : MonoBehaviour
{
    Player player;
    ModeObserver modeObserver;
    public int WeaponIndex;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        modeObserver = this.gameObject.GetComponent<ModeObserver>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player>().SwitchWeapon(WeaponIndex);
            Debug.Log($"Switch Weapon To {WeaponIndex}");
            ModeControl.Instance.modeObservers.Remove(modeObserver);
            Destroy(this.gameObject);
        }
    }
}
