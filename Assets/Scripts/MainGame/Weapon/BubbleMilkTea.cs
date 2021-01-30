using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame.Weapon
{
    public class BubbleMilkTea : MonoBehaviour, IWeapon
    {
        [SerializeField] private GameObject bubble;

        [SerializeField] private float cdTime = 0.5f;
        private bool _coolDown = true;
        private FollowCamera _followCamera;
        private Animator _animator;
        private static readonly int Fire = Animator.StringToHash("Fire");
        private void Start()
        {
            _followCamera = FindObjectOfType<FollowCamera>();
            _animator = GetComponent<Animator>();
        }

        private IEnumerator DoAttack(Vector2 pos, Vector2 dir)
        {
            _coolDown = false;
            var projectile = Instantiate(bubble, pos, Quaternion.identity).GetComponent<Projectile>();
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