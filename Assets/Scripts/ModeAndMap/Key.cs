using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Door targetDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetDoor.Open();
            ModeObserver m = this.gameObject.GetComponent<ModeObserver>();
            ModeControl.Instance.modeObservers.Remove(m);
            Destroy(this.gameObject);
        }
    }

}
