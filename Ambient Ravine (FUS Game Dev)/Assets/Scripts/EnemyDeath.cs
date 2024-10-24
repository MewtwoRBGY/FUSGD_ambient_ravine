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

    //TODO: Put this in playercontroller and allow it to call damage method.
    void OnTriggerEnter2D(Collider2D other)
    {
        /*if(other.gameObject.tag == "Feet")
        {
            foreach(var col in gameObject.GetComponentsInChildren<Collider2D>())
            {
                col.enabled = false;
            }  
            sound.Stop();
            rb.velocity = new Vector2(0f,0f);
            rb.gravityScale = 0; 
            anim.SetBool("dead", true);
        }*/
    }

    public void Damage(float Damage)
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
