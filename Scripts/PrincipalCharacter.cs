using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrincipalCharacter : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    public float gravity;
    private Vector3 movement;
    private CharacterController character;
    public int jumpsMax; //double jump
    public int jumpsCount; //double jump

    [SerializeField] private AudioSource jumpSound;
    
    void Awake()
    {
        character = GetComponent<CharacterController>();
    }

 
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal")* speed; //go forward, go backward
        movement.y -= gravity * Time.deltaTime; //jump
        character.Move(movement * Time.deltaTime);
        
       
        if (character.isGrounded) // add gravity (for jump and fall)
        {           
            movement.y = 0;
            jumpsCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsCount < jumpsMax) //jump condition
        {
            movement.y = jumpSpeed;
            jumpsCount++;
            jumpSound.Play();
        }          
    }

    void OnTriggerEnter (Collider other)
    {           
        if (other.gameObject.tag == "SpeedZone")

        {
            speed = 20;          
        }

        if (other.gameObject.tag == "NormalSpeed")

        {
            speed = 10;
        }
    }   
}
