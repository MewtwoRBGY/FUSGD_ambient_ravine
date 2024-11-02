using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : Bullets
{

    public override void Shoot(Transform Firepoint)
    {
        for(int i = -1; i <= 1; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);

            bullet.AddComponent<Fired>().CurrentBulletType = TOB.GetComponent<ShotGunBullet>(); 

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.AddForce((Firepoint.up + i*(Firepoint.right)/6).normalized * Speed, ForceMode2D.Impulse);
        }
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
