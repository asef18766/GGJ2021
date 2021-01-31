using System;
using System.Collections;
using UnityEngine;

namespace MainGame.Enemy
{
    public class Rain : MonoBehaviour, IEnemy, IHideable
    {
        private Player.Player _player;
        private Rigidbody2D _rb;
        private int _curHealth;
        private bool _coolDown = true;
        /*
         * normal: true
         * found: false
         */
        [SerializeField] private bool normalOrFound;
        [SerializeField] private float mvSpeed = 1;
        [SerializeField] private int maxHealth = 2;
        [SerializeField] private int dmg = 1;
        [SerializeField] private float cd = 0.8f;
        [SerializeField] private DamageZone dmgZone;
        [SerializeField] private float detectRange = 10f;
        private void Start()
        {
            _player = GameObject.Find("Player").GetComponent<Player.Player>();
            _rb = GetComponent<Rigidbody2D>();
            _curHealth = maxHealth;
            dmgZone.damage = dmg;
            dmgZone.gameObject.SetActive(false);
        }

        public IEnumerator wither()
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(5f);
            _die();
        }

        private IEnumerator DoAttack(Vector2 pos, Vector2 dir)
        {
            _coolDown = false;

            dmgZone.gameObject.SetActive(true);

            dmgZone.transform.parent.rotation = Quaternion.identity;
            var angle = Mathf.Acos(dir.normalized.x) / (2 * Math.PI) * 360 * ((dir.y < 0) ? -1 : 1);
            dmgZone.transform.parent.Rotate(0, 0, (float)angle);

            yield return new WaitForSeconds(0.1f);
            dmgZone.gameObject.SetActive(false);

            yield return new WaitForSeconds(cd);
            _coolDown = true;
        }
        public void Attack()
        {
            if (!_coolDown) return;
            //print("enemy attack!!");
            var position = transform.position;
            StartCoroutine(DoAttack(position, _player.transform.position - position));
        }

        private void _die()
        {
            //print("enemy die");
            EnemyCounter.Instance.RemoveEnemy(this);
            Destroy(gameObject);
        }
        public void Hurt(int dmg)
        {
            _curHealth -= dmg;
            if (_curHealth <= 0)
            {
                _die();
            }
        }

        public void Move()
        {
            Vector3 dir = _player.transform.position - transform.position;
            if (dir.sqrMagnitude <= detectRange * detectRange)
                _rb.AddForce(dir.normalized * mvSpeed);
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            //print("found player");
            Attack();
        }

        public void SwitchLost()
        {
            if (normalOrFound)
            {
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }

        public void SwitchFound()
        {
            if (normalOrFound == false)
            {
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }

        private void OnEnable()
        {
            _coolDown = true; // 刷新HITBOX避免開不了
        }

    }
}