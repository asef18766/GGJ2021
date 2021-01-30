using UnityEngine;

namespace MainGame.Player
{
    [CreateAssetMenu(fileName = "MainGame/PlayerProp", menuName = "PlayerProp", order = 0)]
    public class PlayerProp : ScriptableObject
    {
        public int atk;
        public int atkSpeed;
        public int atkRange;
        public int maxHealth;
        public int mvSpeed;

        public void Copy(PlayerProp other)
        {
            atk = other.atk;
            atkSpeed = other.atkSpeed;
            atkRange = other.atkRange;
            maxHealth = other.maxHealth;
            mvSpeed = other.mvSpeed;
        }
    }
}