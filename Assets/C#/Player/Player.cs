using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField]
    private PlayerInput _playerInput;
    [SerializeField]
    private Rigidbody2D _playerRigidBody;
    [SerializeField]
    private Transform _playerSprite, _swordArc;
    [SerializeField]
    private SpriteRenderer _swordArcSprite;
    [SerializeField]
    private PlayerAnimationScript _playerAnim;
    private bool _grounded, _canJump = true, _canAttack = true;
    [SerializeField]
    private float _speed = 3.5f, _jumpForec;
    private float _horizontalInput, _stickInput;
  
    
    public int _diamondHave;
    public int DamageableHealth { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        DamageableHealth = 4;
        _playerInput = new PlayerInput();
        _playerInput.PlayerControl.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
        GameManager.Program.GemsPlayerGot(_diamondHave);
       

    }
    private void Movement()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _stickInput = _playerInput.PlayerControl.Movement.ReadValue<float>();
        //Key movement
        Vector3 facing = transform.localEulerAngles;
        facing.y = _playerRigidBody.velocity.x > 0 ? 0 : 180;
        
        _playerAnim.WalkRun(Mathf.Abs(_horizontalInput));
        _grounded = IsGrounded();
        if (_horizontalInput != 0)
        {

            _playerSprite.transform.localEulerAngles = facing;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _playerAnim.WalkRun(Mathf.Abs(_horizontalInput) + 1);
                _speed = 4.5f;
            }
            else
            {
                _speed = 3.5f;
            }
           
        }

        if (Input.GetKeyDown(KeyCode.Space) || _playerInput.PlayerControl.Jump.triggered == true && IsGrounded() == true)
        {
            _jumpForec = 7;
            _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, _jumpForec);
            _playerAnim.Jump(true);
            StartCoroutine(JumpAgain());
        }

        _playerRigidBody.velocity = new Vector2(_horizontalInput * _speed, _playerRigidBody.velocity.y);

        //Ui Stick movement
       
        if (_horizontalInput == 0)
        {
            _playerRigidBody.velocity = new Vector2(_stickInput * _speed, _playerRigidBody.velocity.y);
            _playerAnim.WalkRun(Mathf.Abs(_stickInput));
            if(_stickInput != 0)
            {
                _playerSprite.transform.localEulerAngles = facing;
            }
        }
       


    }
    private void Attack()
    {
        Vector3 SwordArcFacing;
        //key input
        if(_horizontalInput == 1)
        {
            SwordArcFacing = new Vector3(0.88f, 0.1f, 0);
            _swordArc.transform.localPosition = SwordArcFacing;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;
        }
        if (_horizontalInput == -1)
        {
            SwordArcFacing = new Vector3(-0.88f, 0.1f, 0);
            _swordArc.transform.localPosition = SwordArcFacing;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;
        }

       
      
        if (Input.GetKeyDown(KeyCode.Z) && _canAttack == true && IsGrounded() == true)
        {
            _playerAnim.Attack(true);
            _canAttack = false;
            StartCoroutine(AttackDone());
        }
        //Ui Input
        if (_stickInput == 1)
        {
            SwordArcFacing = new Vector3(0.88f, 0.1f, 0);
            _swordArc.transform.localPosition = SwordArcFacing;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;
        }
        if (_stickInput == -1)
        {
            SwordArcFacing = new Vector3(-0.88f, 0.1f, 0);
            _swordArc.transform.localPosition = SwordArcFacing;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;
        }
        if (_playerInput.PlayerControl.Attack.triggered == true && _canAttack == true && IsGrounded() == true)
        {
            _playerAnim.Attack(true);
            _canAttack = false;
            StartCoroutine(AttackDone());
        }
    }
    bool IsGrounded()
    { 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 7);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        if (hit.collider != null)
        {
            if (_canJump == true)
            {
                _playerAnim.Jump(false);
                return true;
            }
           
        }
        return false;
    }
    IEnumerator JumpAgain()
    {
        _canJump = false;
        yield return new WaitForSeconds(0.1f);
        _canJump = true;
    }
    IEnumerator AttackDone()
    {
      
        yield return new WaitForSeconds(0.24f);
        _playerAnim.Attack(false);
        _canAttack = true;
    }

    public void Damage(int Damage)
    {
        Debug.Log("PlayerHit");
        DamageableHealth -= Damage;
        GameManager.Program.PlayerHealth(DamageableHealth);
        if (DamageableHealth == 0)
        {
            Death();
        }

    }
    private void Death()
    {
        _playerAnim.Death();
        GameManager.Program.PlayerIsDead();
        Destroy(this.gameObject, 2);
    }
   
  


}
