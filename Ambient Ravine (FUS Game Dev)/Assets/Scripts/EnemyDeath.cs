using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class EnemyDeath : MonoBehaviour, IDamageable
{
    [SerializeField]
    float health = 10;

    Animator anim;
    Rigidbody2D rb;
    AudioSource sound;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }

    public void Damage(float Damage, Vector2 Knockback)
    {
        health = health - Damage ;
        if (health <= 0)
        {
            Die();
        } else
        {
            Debug.Log("Health Lost! Current Health: " + health);
        }
    }

    public void Die()
    {
        Debug.Log(gameObject.name + " just died.");
        Destroy(gameObject);
    }
}
