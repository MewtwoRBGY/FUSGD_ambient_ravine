using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    float Damage;
    [SerializeField]
    float KnockTime;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            IDamageable damageable = collider2D.GetComponent<IDamageable>();
            Debug.Log(collider2D.name);
            if (damageable != null)
            {
                Rigidbody2D rb2 = collider2D.GetComponent<Rigidbody2D>();
                Vector2 Knockback = (-(Vector2)transform.position + (Vector2)collider2D.transform.position).normalized;

                rb2.AddForce(Knockback*20, ForceMode2D.Impulse);
                StartCoroutine(KnockbackTimer(rb2));

                damageable.Damage(Damage);
                
            }
        }
    }

    private IEnumerator KnockbackTimer(Rigidbody2D rigidbody2D) {
        yield return new WaitForSeconds(KnockTime);
        rigidbody2D.velocity = Vector2.zero;
    }
}
