using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : Bullets
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    string GunName = "Gun";

    [SerializeField]
    float BulletSpeed = 20f;

    [SerializeField]
    int BulletAmount = 10;

    [SerializeField]
    float CoolDownf = 5;

    [SerializeField]
    int BulletSpreadAmount = 3;

    [SerializeField]
    float Damage = 3;

    [SerializeField]
    float Recoil = 2;


    private void Awake()
    {
        Speed = BulletSpeed;
        AmmoCount = BulletAmount;
        CoolDown = CoolDownf;
        WeaponName = GunName;
    }


    public override void Shoot(Transform Firepoint)
    {
        for(int i = -1; i <= 1; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);

            bullet.AddComponent<Fired>();

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.AddForce((Firepoint.up + i*(Firepoint.right)/6).normalized * Speed, ForceMode2D.Impulse);
        }
    }

    public override void OnHit(Collider2D collider2D)
    {
        IDamageable damageable = collider2D.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(Damage, Vector2.zero);
        }
        Destroy(gameObject);
    }

    public override void Fired()
    {
        Destroy(gameObject, 5f);
    }
}
