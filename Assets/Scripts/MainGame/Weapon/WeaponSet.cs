using System;
using System.Collections.Generic;
using UnityEngine;


namespace MainGame.Weapon
{
    [CreateAssetMenu(fileName = "MainGame/WeaponSet", menuName = "WeaponSet", order = 0)]
    public class WeaponSet : ScriptableObject
    {
        [SerializeField] private List<GameObject> slot;

        public GameObject GetWeapon(int idx)
        {
            if (idx < 0 || idx >= slot.Count)
                throw new IndexOutOfRangeException($"invalid index {idx}");
            return slot[idx];
        }
    }
}