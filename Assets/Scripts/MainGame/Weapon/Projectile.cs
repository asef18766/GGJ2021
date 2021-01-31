using System;
using MainGame.Enemy;
using UnityEngine;

namespace MainGame.Weapon
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        [SerializeField] private int dmg = 1;
        [SerializeField] private string target = "Enemy";
        
        public void SetDir(Vector2 dir)
        {
            GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Terrain")) Destroy(gameObject);
            if(target=="Enemy")
            {
                if (!other.CompareTag("Enemy")) return;
                other.GetComponent<IEnemy>().Hurt(dmg);
            }
            else
            {
                if (!other.CompareTag("Player")) return;
                var player = other.GetComponent<Player.Player>();
                player.StartCoroutine("_hurt", dmg);
            }
            Destroy(gameObject);
        }
    }
}