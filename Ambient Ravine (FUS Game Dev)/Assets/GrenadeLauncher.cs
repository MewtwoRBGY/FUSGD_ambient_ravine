using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Bullets
{

    Collider2D[] ColliderList;

    [SerializeField]
    GameObject Explosion;

    [SerializeField]
    float Radius;

    public override void Shoot(Transform Firepoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
        bullet.AddComponent<Fired>().CurrentBulletType = TOB.GetComponent<GrenadeLauncher>(); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Firepoint.up * Speed, ForceMode2D.Impulse);
    }

    public override void OnHit(Collider2D collider2D, GameObject GOBullet)
    {
            Collider2D[] hits = Physics2D.OverlapCircleAll(GOBullet.transform.position, Radius, 1);
            
            StartCoroutine(Explode(hits, GOBullet));
    }

    private IEnumerator Explode(Collider2D[] hits, GameObject GOBullet)
    {
        yield return new WaitForSeconds(2);
        ExplosionEffect(GOBullet);
        foreach (Collider2D hit in hits)
            {
                if (hit != null)
                {
                    IDamageable damageable = hit.GetComponent<IDamageable>();
                    if (damageable != null)
                        {
                            damageable.Damage(Damage, Vector2.zero);
                        }
                }
                
             
            }
    } 

    private void ExplosionEffect(GameObject PointOfExplosion)
    {
        GameObject ExplosionEffectOS = Instantiate(Explosion, PointOfExplosion.transform);
        ExplosionEffectOS.transform.localScale = new Vector3(Radius*9.5f, Radius*9.5f, 0);
        Destroy(ExplosionEffectOS, .4f);
        Destroy(PointOfExplosion, .5f);
    }

    public override void Fired(GameObject GOBullet)
    {
        
    }
}
