using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Change InputManager to InputManager(New) in Project Settings -> Player Settings and download InputSystem in PackageManager to make this script work.
//NOTE: Check Packages in registry not in project

public class PlayerController : MonoBehaviour
{
    //SerializeField makes it visible and editable in Inspector while keeping the variable as private
    [SerializeField] InputAction move; //Check bindings on the player's PlayerMover script
    [SerializeField] InputAction jump;
    [SerializeField] InputAction fall;

    //[SerializeField] 
    [Header("Jump System")]
    [SerializeField] float mvmSpd = 5f;
    [SerializeField] float jmpSpd = 8f;
    [SerializeField] float airSpdCoEff = .75f;
    [SerializeField] float dropSpd = 1f;
    [SerializeField] float maxFallVelocity = 20f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    float groundCheckRadius = 0.2f;
    public bool canMove = true;

    Rigidbody2D player;

   

    //Enables and disables the move and jump buttons when Unity calls OnEnable and OnDisable
    void OnEnable()
    {
        move.Enable();
        jump.Enable();
        fall.Enable();
    }
    void OnDisable()
    {
        move.Disable();
        jump.Disable();
        fall.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!canMove)
        {
            return;
        }
        //Processes these every single frame
        Walk();
        Jump();
    }

    void Walk()
    {
        float walk = Time.deltaTime * mvmSpd * move.ReadValue<float>(); //Since Update is called every frame Time.deltaTime makes it so movement speed is not tied to framerate
        if(!isGrounded())
        {
            walk *= airSpdCoEff; //Reduces airspeed
        }
        if(walk != 0)
        {
            transform.Translate(walk, 0, 0); //Moves character
        }
        
    }

    void Jump()
    {
        //Jump works in the air and infintely due to not checking if touching the ground. The BetterPlayerMover script fixes this.
       if(jump.ReadValue<float>() > 0.0 && isGrounded())
        {
            player.velocity = new Vector2(player.velocity.x, jmpSpd);
            
        }
        else if(!isGrounded() && fall.ReadValue<float>() > 0.0 && player.velocity.y > -1.0f * maxFallVelocity)
        {
            player.velocity = new Vector2(player.velocity.x, player.velocity.y - dropSpd);
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
