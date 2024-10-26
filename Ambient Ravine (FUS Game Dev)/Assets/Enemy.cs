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
            if (damageable != null)
            {
                Rigidbody2D rb2 = collider2D.GetComponent<Rigidbody2D>();
                Vector2 Knockback = (-(Vector2)transform.position + (Vector2)collider2D.transform.position).normalized;

                StartCoroutine(KnockbackTimer(rb2));

                damageable.Damage(Damage, Knockback);

            }
        }
    }

    private IEnumerator KnockbackTimer(Rigidbody2D rigidbody2D) {
        yield return new WaitForSeconds(KnockTime);
        rigidbody2D.velocity = Vector2.zero;
    }
}
