using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace MainGame.Weapon
{
    public class Wallet : MonoBehaviour, IWeapon
    {
        [SerializeField] private List<GameObject> ammos;

        [SerializeField] private float cdTime = 0.5f;
        private bool _coolDown = true;
        private FollowCamera _followCamera;
        private Animator _animator;
        private static readonly int Fire = Animator.StringToHash("Fire");
        private Random _random;
        private void Start()
        {
            _followCamera = FindObjectOfType<FollowCamera>();
            _animator = GetComponent<Animator>();
            _random = new Random();
            _random.InitState();
        }

        private IEnumerator DoAttack(Vector2 pos, Vector2 dir)
        {
            _coolDown = false;
            var ammo = ammos[_random.NextInt(0, ammos.Count)];
            var projectile = Instantiate(ammo, pos, Quaternion.identity).GetComponent<Projectile>();
            projectile.SetDir(dir);
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
    }
}