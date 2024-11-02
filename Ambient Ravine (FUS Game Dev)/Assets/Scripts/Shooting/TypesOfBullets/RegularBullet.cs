using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Security.Cryptography;

public class RegularBullet : Bullets
{

    public override void Shoot(Transform Firepoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
        bullet.AddComponent<Fired>().CurrentBulletType = TOB.GetComponent<RegularBullet>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Firepoint.up * Speed, ForceMode2D.Impulse);
    }

    public override void OnHit(Collider2D collider2D, GameObject GOBullet)
    {
        IDamageable damageable = collider2D.GetComponent<IDamageable>();
        if (damageable != null) 
        {
            damageable.Damage(Damage, Vector2.zero);
        }
        Destroy(GOBullet);
    } 

    public override void Fired(GameObject GOBullet)
    {
        Destroy(GOBullet, 5f);
    }
}
