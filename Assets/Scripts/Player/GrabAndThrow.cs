using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrabAndThrow : MonoBehaviour {

    public bool grabbed;

    public Collider2D hit;

    [SerializeField]
    private float distance = 5f;

    [SerializeField]
    private Transform holdPoint;

    [SerializeField]
    private Transform grabPosition;

    [SerializeField]
    private float throwForce = 10f;
    
    //private Animator anim;

    public LayerMask notGrabbed;

    public LayerMask items;

    [SerializeField]
    public float angle;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        

        if (Input.GetButtonDown("Fire1"))
        {
            if (!grabbed)
            {
                //grab

                Physics2D.queriesStartInColliders = false;

               hit = Physics2D.OverlapCircle(grabPosition.position, distance, items);
               
                if (hit!=null && hit.tag == "GrabObject")
                {
                    grabbed = true;
                }

            }
            else if (!Physics2D.OverlapPoint(holdPoint.position, notGrabbed))
            { 

                //throw

                grabbed = false;

                if (hit.gameObject.GetComponent<Rigidbody2D>()!=null)
                {
                    hit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, angle)*throwForce;
                    
                }
            }
        }

        //holds item to player
        if (grabbed)
        {
            hit.gameObject.transform.position = holdPoint.position;
        }

	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(grabPosition.position, distance);
    }

    
}
