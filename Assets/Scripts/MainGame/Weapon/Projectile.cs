using System;
using MainGame.Enemy;
using UnityEngine;

namespace MainGame.Weapon
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        [SerializeField] private int dmg = 1;
        
        public void SetDir(Vector2 dir)
        {
            GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Terrain")) Destroy(gameObject);
            if (!other.CompareTag("Enemy")) return;

            other.GetComponent<IEnemy>().Hurt(dmg);
            Destroy(gameObject);
        }
    }
}