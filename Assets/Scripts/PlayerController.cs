using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    
    private bool isGrounded;
    private bool canDJump;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private Animator anim;
    private SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        if(isGrounded)
        {
            canDJump=true;
        }

    if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else
            {
                if(canDJump)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDJump=false;
                }
            }
        } 

        if(theRB.velocity.x < 0)
        {
            theSR.flipX=true;
        }
        else if(theRB.velocity.x > 0)
        {
            theSR.flipX=false;
        }

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
    }
}
