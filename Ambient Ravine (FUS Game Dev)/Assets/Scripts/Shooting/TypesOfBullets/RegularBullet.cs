using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RegularBullet : Bullets
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


    private void Awake()
    {
        Speed = BulletSpeed;
        AmmoCount = BulletAmount;
        CoolDown = CoolDownf;
        WeaponName = GunName;
    }


    public override void Shoot(Transform Firepoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
        bullet.AddComponent<Fired>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Firepoint.up * Speed, ForceMode2D.Impulse);
    }

    public override void OnHit()
    {
        Destroy(gameObject);
    }

    public override void Fired()
    {
        Destroy(gameObject, 5f);
    }
}
