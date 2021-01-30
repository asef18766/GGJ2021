using System;
using UnityEngine;

namespace MainGame.Enemy
{
    public class DamageZone : MonoBehaviour
    {
        public int damage;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            var player = other.gameObject.GetComponent<Player.Player>();
            player.StartCoroutine("_hurt", damage);
        }
    }
}