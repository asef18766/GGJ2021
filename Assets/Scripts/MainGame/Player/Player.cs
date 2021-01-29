using System.Collections;
using MainGame.Weapon;
using UnityEngine;

namespace MainGame.Player
{
    public class Player : MonoBehaviour
    {
        private int _curHealth;
        private IWeapon _curWeapon;
        private Rigidbody2D _rigidbody;
        [SerializeField] private WeaponSet weaponSet;
        [SerializeField] private PlayerProp playerProp;
        [SerializeField] private KeyCode atkKeyCode = KeyCode.Mouse0;
        [SerializeField] private KeyCode upKeyCode = KeyCode.W;
        [SerializeField] private KeyCode downKeyCode = KeyCode.S;
        [SerializeField] private KeyCode leftKeyCode = KeyCode.A;
        [SerializeField] private KeyCode rightKeyCode = KeyCode.D;

        // Start is called before the first frame update
        private void Start()
        {
            var weapon = weaponSet.GetWeapon(0);
            _curWeapon = Instantiate(weapon, transform).GetComponentInChildren<IWeapon>();
            if (_curWeapon == null)
                print("cur weapon is null!!");

            _curHealth = playerProp.maxHealth;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void ScanKey()
        {
            if (Input.GetKey(atkKeyCode))
            {
                //do attack
                var mousePos = Input.mousePosition;
                mousePos.z = Camera.main.nearClipPlane;
                var position = transform.position;
                
                var atkDir = position - Camera.main.ScreenToWorldPoint(mousePos);
                atkDir = atkDir.normalized;
                _curWeapon.Attack(position, atkDir);
            }
            
            // move
            var mvVec = new Vector2();
            if (Input.GetKey(upKeyCode))
                mvVec += Vector2.up;
            if (Input.GetKey(downKeyCode))
                mvVec += Vector2.down;
            if (Input.GetKey(leftKeyCode))
                mvVec += Vector2.left;
            if (Input.GetKey(rightKeyCode))
                mvVec += Vector2.right;
            
            _rigidbody.AddForce(mvVec.normalized * playerProp.mvSpeed);
        }

        private void _die()
        {
            print("player dead");
        }
        private IEnumerator _hurt(int dmg)
        {
            print("player hurt!!");
            _curHealth -= dmg;
            if (_curHealth <= 0)
            {
                _die();
            }
            yield break;
        }
        
        // Update is called once per frame
        private void Update()
        {
            ScanKey();
        }
    }
}
