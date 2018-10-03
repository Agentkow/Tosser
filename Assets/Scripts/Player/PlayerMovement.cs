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

    private bool facingRight = true;

    private RaycastHit2D checkJump;

    // Use this for initialization
    void Start () {

        rigBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rigBody.velocity = new Vector2(move * moveSpeed, rigBody.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();


    }

    // Update is called once per frame
    void Update () {

        checkJump = Physics2D.Raycast(transform.position,transform.TransformDirection(Vector2.down),rayLength);

        if (checkJump)
        {
            hadJumped = false;
        }

        if (Input.GetButtonDown("Jump") && !hadJumped)
        {
            rigBody.AddForce(new Vector2(0, jumpHeight));
            hadJumped = true;
        }
        

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    
}
