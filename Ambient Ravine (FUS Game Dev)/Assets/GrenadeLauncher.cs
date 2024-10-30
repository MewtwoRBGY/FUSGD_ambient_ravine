using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Bullets
{

    [SerializeField] 
    LayerMask Damageables;

    private bool Strike = false;

    Collider2D[] ColliderList;

    public override void Shoot(Transform Firepoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
        bullet.AddComponent<Fired>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Firepoint.up * Speed, ForceMode2D.Impulse);
    }

    public override void OnHit(Collider2D collider2D)
    {
        if (Strike == false)
        {
            Strike = true;

            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 3, 1);
            foreach (Collider2D hit in hits)
            {
                IDamageable damageable = hit.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.Damage(Damage, Vector2.zero);
                }
            }
        }
    }

    public override void Fired()
    {
        Destroy(gameObject, 5f);
    }
}
