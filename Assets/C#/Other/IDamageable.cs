using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    int DamageableHealth { get; set; }
    void Damage(int Damage);
}
