using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public LayerMask groundLayer;
    public float groundDistance;
    Rigidbody2D rb;
    public bool grounded;
    public float jumpSpeed;
    public float moveSpeed;
    public AudioSource JumpSound;

    void Start()
    {
        JumpSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit =  Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        grounded = hit.collider != null;
        print(hit);
        if(Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
            
            

        }
        float h = Input.GetAxis("Horizontal");
        rb.velocity =  new Vector2(h * moveSpeed, rb.velocity.y);
        
        if(h !=0)
        {
            float angle = h > 0 ? 0 : 180;
            transform.eulerAngles = new Vector3(0, h > 0 ? 0 : 180, 0);
        }
        

    }
    void Jump()
    {
        rb.velocity = Vector2.up * jumpSpeed;
        JumpSound.PlayOneShot(JumpSound.clip);
    }


}
