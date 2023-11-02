using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour , IDamageable
{
    private int _speed = 1;

    public int DamageableHealth { get; set; }

   

    private void Start()
    {
        Destroy(this.gameObject, 5f);
        DamageableHealth = 1;
    }
    private void Update()
    {
        transform.Translate( Vector3.right * _speed * Time.deltaTime);
    }
    public void Damage()
    {
        DamageableHealth -= 1;
        if (DamageableHealth == 0)
        {
            Debug.Log("kcon");
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
                
        }
    }
}
