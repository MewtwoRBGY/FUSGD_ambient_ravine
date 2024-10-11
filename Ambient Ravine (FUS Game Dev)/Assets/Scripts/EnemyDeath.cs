using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    AudioSource sound;
    void Awake()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Feet")
        {
            foreach(var col in gameObject.GetComponentsInChildren<Collider2D>())
            {
                col.enabled = false;
            }  
            sound.Stop();
            rb.velocity = new Vector2(0f,0f);
            rb.gravityScale = 0; 
            anim.SetBool("dead", true);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
