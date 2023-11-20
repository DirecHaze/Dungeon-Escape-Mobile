using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canBeAttack = true;
    private void OnTriggerEnter2D(Collider2D Other)
    {
        Debug.Log("Hit: " + Other.name);
        IDamageable TargetHit = Other.GetComponent<IDamageable>();
        if (TargetHit != null)
        {
            if (_canBeAttack == true)
            {
                TargetHit.Damage(1);
                StartCoroutine(AttackAgain());
                
            }
        }
    }
    IEnumerator AttackAgain()
    {
        _canBeAttack = false;
        yield return new WaitForSeconds(0.5f);
        _canBeAttack = true;
    }
}
