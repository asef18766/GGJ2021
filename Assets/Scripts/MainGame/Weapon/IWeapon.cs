using UnityEngine;

namespace MainGame.Weapon
{
    public interface IWeapon
    {
        void Attack(Vector2 pos, Vector2 dir);
    }
}