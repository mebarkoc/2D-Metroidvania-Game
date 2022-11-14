using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;

    public float moveSpeed;
    public float jumpForce;

    public Transform groundPoint;
    private bool isOnGround;
    public LayerMask whatIsGround;

    public Animator anim;

    public BulletController shotToFire;
    public Transform shotPoint;

    void Start()
    {

    }
    
    void Update()
    {
        //move sideways
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        //handle direction change
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (theRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one; 
        }

        //checking if on ground
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

        //jumping
        if(Input.GetButtonDown("Jump") && isOnGround == true)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDir = new Vector2(transform.localScale.x, 0f);
        }








        anim.SetBool("inOnGround", isOnGround);
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
    }
}
