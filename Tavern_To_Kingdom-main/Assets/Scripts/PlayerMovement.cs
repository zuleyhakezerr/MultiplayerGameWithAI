using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public float Speed = 5f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    Animator anim;



    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");       
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 7f;
        }
        else Speed = 5f;
        controller.Move(move * Speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        #region Animasyon
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Yürü", true);
        }
        else
        {
            anim.SetBool("Yürü", false);
        }
        if (Input.GetKey(KeyCode.D))
        {            
            anim.SetBool("Right", true);
        }
        else
        {            
            anim.SetBool("Right", false);
        }
        if (Input.GetKey(KeyCode.A))
        {            
            anim.SetBool("Left", true);
        }
        else
        {            
            anim.SetBool("Left", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Back", true);
        }
        else
        {
            anim.SetBool("Back", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            anim.SetBool("BackRight", true);
        }
        else
        {
            anim.SetBool("BackRight", false);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("BackLeft", true);
        }
        else
        {
            anim.SetBool("BackLeft", false);
        }
        #endregion
    }
}
