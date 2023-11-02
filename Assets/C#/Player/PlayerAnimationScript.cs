using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    [SerializeField]
    private Animator _playerAnim, _swordArcAnim;
    
    public void Jump(bool Bool)
    {
        _playerAnim.SetBool("Jump", Bool);
    }
    public void WalkRun(float Speed)
    {
        _playerAnim.SetFloat("Speed", Speed);
    }
    public void Attack(bool Bool)
    {
        _playerAnim.SetBool("Attack", Bool);
        _swordArcAnim.SetBool("Attack", Bool);
    }
    public void Death()
    {
        _playerAnim.SetTrigger("Death");
    }
}
