using System.Collections;
using MainGame.Enemy;
using UnityEngine;

namespace MainGame.Weapon
{
    public class Jacket : MonoBehaviour, IWeapon
    {
        [SerializeField] private int dmg = 3;
        [SerializeField] private float cdTime = 0.8f;
        private bool _coolDown = true;
        private BoxCollider2D _boxCollider2D;
        private FollowCamera _followCamera;
        private Animator _animator;
        private static readonly int Fire = Animator.StringToHash("Fire");

        private void Start()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _boxCollider2D.enabled = false;
            _followCamera = FindObjectOfType<FollowCamera>();
            _animator = GetComponent<Animator>();
        }

        private IEnumerator DoAttack(Vector2 pos, Vector2 dir)
        {
            _coolDown = false;

            _boxCollider2D.enabled = true;
            yield return new WaitForSeconds(0.1f);
            _boxCollider2D.enabled = false;
            yield return new WaitForSeconds(cdTime);
            _coolDown = true;
        }

        public void Attack(Vector2 pos, Vector2 dir)
        {
            if (!_coolDown)
                return;
            
            StartCoroutine(DoAttack(pos, dir));
            _animator.SetTrigger(Fire);
            print("attack!!");
            _followCamera.StartCoroutine(_followCamera.CameraShake(0.1f, 0.1f));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return;
            
            print("hit");
            var enemy = other.GetComponent<IEnemy>();
            enemy.Hurt(dmg);
        }
    }
}