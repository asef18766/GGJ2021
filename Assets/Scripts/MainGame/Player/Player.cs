using System.Collections;
using MainGame.Weapon;
using UnityEngine;

namespace MainGame.Player
{
    public class Player : MonoBehaviour
    {
        private IWeapon _curWeapon;
        private Rigidbody2D _rigidbody;
        private Camera _camera;
        private GameObject _weapon;

        [SerializeField] private WeaponSet weaponSet;
        
        [SerializeField] private PlayerProp playerProp;
        [SerializeField] private PlayerProp curPlayerProp;
        
        [SerializeField] private KeyCode atkKeyCode = KeyCode.Mouse0;
        [SerializeField] private KeyCode upKeyCode = KeyCode.W;
        [SerializeField] private KeyCode downKeyCode = KeyCode.S;
        [SerializeField] private KeyCode leftKeyCode = KeyCode.A;
        [SerializeField] private KeyCode rightKeyCode = KeyCode.D;
        
        // Start is called before the first frame update
        private void Start()
        {
            _camera = Camera.main;
            _weapon = weaponSet.GetWeapon(0);
            _weapon = Instantiate(_weapon, transform);
            _curWeapon = _weapon.GetComponentInChildren<IWeapon>();
            if (_curWeapon == null)
                print("cur weapon is null!!");
            
            curPlayerProp.Copy(playerProp);
            
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void ScanKey()
        {
            var mousePos = Input.mousePosition;
            mousePos.z = _camera.nearClipPlane;
            var position = transform.position;
                
            var atkDir =  _camera.ScreenToWorldPoint(mousePos) - position;
            var rotate = Vector2.Angle(Vector2.right, atkDir);
            if (atkDir.y < 0)
                rotate = -rotate;
            _weapon.transform.rotation = Quaternion.identity;
            _weapon.transform.Rotate(0,0,rotate);
            
            if (Input.GetKey(atkKeyCode))
            {
                //do attack
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
            curPlayerProp.maxHealth -= dmg;
            if (curPlayerProp.maxHealth <= 0)
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

        public void SwitchWeapon(int idx)
        {
            Destroy(_weapon);
            _weapon = weaponSet.GetWeapon(idx);
            _weapon = Instantiate(_weapon, transform);
            _curWeapon = _weapon.GetComponentInChildren<IWeapon>();
        }

        public PlayerProp GetCurPlayerProp()
        {
            return curPlayerProp;
        }
    }
}
