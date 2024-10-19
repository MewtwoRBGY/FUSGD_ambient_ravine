using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Bullets : MonoBehaviour
{
    public int AmmoCount { get; set; }
    public float Speed { get; set; }

    public string WeaponName { get; set; }
    public float CoolDown { get; set; }

    /// <summary>
    /// Fires an object from a certain position
    /// </summary>
    public abstract void Shoot(Transform Firepoint);

    /// <summary>
    /// Called whenever the bullet hits an object with a collider 
    /// </summary>
    public abstract void OnHit(Collider2D collider2D);

    /// <summary>
    /// Called whenever the object is first fired. To be used for any specific things that need to happen while in the air. (Probably wont be used much but just in case.)
    /// </summary>
    public abstract void Fired();
}

