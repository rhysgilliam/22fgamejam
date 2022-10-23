using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Rigidbody2D enragedRb;
    private SpriteRenderer sr;
    private Animator anim;
    public SpriteRenderer enragedSR;
    private float movementX;
    private float movementY;
    public float speed = 1;
    public GameObject enragedPlayer;
    public GameObject enragedSprite;
    public GameObject normalPlayer;
    public FollowPlayer camFlw;
    public static Vector2 lastMove = new Vector2(0, 1); 
    
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

   private void OnMove(InputValue movementValue)
   {
       Vector2 movementVector = movementValue.Get<Vector2>();
 
       movementX = movementVector.x;
       movementY = movementVector.y;
       if (movementX > 0)
       {
            sr.flipX = false;
	   }
       else if(movementX < 0)
       {
            sr.flipX = true;
	   }

       if (movementX != 0 || movementY != 0)
       {    
            anim.SetBool("IsWalking", true);
            lastMove = movementVector;
       }
       else
       {
            anim.SetBool("IsWalking", false);
	   }
   }

   private void OnRage()
   {
        enragedPlayer.transform.position = normalPlayer.transform.position;
        
        enragedPlayer.transform.rotation = normalPlayer.transform.rotation;
        enragedPlayer.transform.Rotate(0, 0, - 90 * lastMove.x);
        if (lastMove.y < 0)
        {
            enragedPlayer.transform.Rotate(0, 0, - 180 * lastMove.y);
		}

        enragedPlayer.SetActive(true);
        enragedSprite.SetActive(true);
        movementX = 0;
        movementY = 0;
        camFlw.player = enragedPlayer.transform;
        normalPlayer.SetActive(false);
    }

   void FixedUpdate()
   {
        Vector2 movement = new Vector2(movementX, movementY);
        rb.AddForce(movement * speed);
   }
}
