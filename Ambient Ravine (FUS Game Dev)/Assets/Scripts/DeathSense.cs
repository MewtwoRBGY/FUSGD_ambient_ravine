using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//TMPro = TextMeshPro, the thing that enables the text to work.
public class DeathSense : MonoBehaviour
{
    [SerializeField] GameObject text; //Stores the text UI Gameobject
    Animator anim;
    Rigidbody2D rb;
    PlayerController move;
    AudioSource sound;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        move = GetComponent<PlayerController>();
        sound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other) //Called when it touches a trigger collider
    {
        if(other.gameObject.tag == "Deadly") //Checks if the trigger's tag is "Deadly"
        {
            move.canMove = false;
            rb.velocity = new Vector2(0f,0f);
            rb.gravityScale = 0;
            foreach(var col in gameObject.GetComponentsInChildren<Collider2D>())
            {
                col.enabled = false;
            }
            sound.Play();
            Debug.Log("Greg"); //Prints to the console
            anim.SetBool("dead", true);
        }
    }

    public void Die()
    {
        Destroy(gameObject); //Destroys the player
        text.SetActive(true); //Sets the text to active
    }
}
