using System.Collections;
using UnityEngine;

namespace MainGame.Weapon
{
    public class Diamond : MonoBehaviour, IWeapon
    {
        [SerializeField] private GameObject diamondMajor;
        private FollowCamera _followCamera;
        private Animator _animator;
        private static readonly int Fire = Animator.StringToHash("Fire");
        private void Start()
        {
            _followCamera = FindObjectOfType<FollowCamera>();
            _animator = GetComponent<Animator>();
        }
        

        public void Attack(Vector2 pos, Vector2 dir)
        {
            _animator.SetTrigger(Fire);
            print("attack!!");
            _followCamera.StartCoroutine(_followCamera.CameraShake(0.1f, 0.1f));
            FindObjectOfType<Player.Player>().SwitchWeapon(0);
            Instantiate(diamondMajor, pos, Quaternion.identity).GetComponent<Projectile>().SetDir(dir);
        }
    }
}