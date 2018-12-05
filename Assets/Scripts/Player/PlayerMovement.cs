using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private float jumpHeight = 20;
    [SerializeField]
    private bool hadJumped = false;
    [SerializeField]
    private float rayLength = 1f;

    private Animator anim;

    private Rigidbody2D rigBody;
    
    private RaycastHit2D checkJump;

    private SpriteRenderer render;

    public bool facingRight= true;
    // Use this for initialization
    void Start () {

        hadJumped = false;
        rigBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
	}

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rigBody.velocity = new Vector2(move * moveSpeed, rigBody.velocity.y);

        if (move > 0 )
        {
            render.flipX = false;
            facingRight = true;
        }
        else if (move < 0 )
        {
            render.flipX = true;
            facingRight = false;
        }
            


    }

    // Update is called once per frame
    void Update () {
        

        checkJump = Physics2D.Raycast(transform.position,transform.TransformDirection(Vector2.down),rayLength);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down), Color.green, rayLength, false);
        
        if (Input.GetButtonDown("Jump") && !hadJumped)
        {

            rigBody.AddForce(new Vector2(0, jumpHeight));

        }

        if (checkJump.collider != null)
        {
            hadJumped = false;
        }
        else if (checkJump.collider == null)
        {

            hadJumped = true;

        }

    }
    
    
}
