using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    /// <summary>
    /// Allows an object to take damage. 
    /// </summary>
    void Damage(float Damage, Vector2 Knockback);
}
