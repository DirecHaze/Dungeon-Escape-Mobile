using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField]
    private GameObject _acidPrefab;
    public override void Movement()
    {
        //Chill Here
    }
    public void Attack()
    {

        Instantiate(_acidPrefab, transform.position, Quaternion.identity);
    }

}
