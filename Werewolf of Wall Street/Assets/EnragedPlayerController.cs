using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnragedPlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject enragedPlayer;
    public GameObject enragedSprite;
    public SpriteRenderer enragedSpriteSR;
    public GameObject normalPlayer;
    public FollowPlayer camFlw;
    private float movementX = 0f;
    private float movementY = 0f;
    public float speed = 1;
    public float rotationSpeed = 1;
    private int YSign = 1;
    private Vector2 dir;
    
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        if (movementY < 0 && YSign == -1)
        {
            YSign = 1;
        }
		else if (movementY < 0 && YSign == 1)
        {
            YSign = -1;  
		}
    }

    void OnRage()
    {
        normalPlayer.SetActive(true);
        normalPlayer.transform.position = enragedPlayer.transform.position;
        camFlw.player = normalPlayer.transform;
        movementX = 0;
        movementY = 0;
        enragedPlayer.SetActive(false);
        enragedSprite.SetActive(false);
    }

    void FixedUpdate()
    {
        rb.rotation = rb.rotation - (rotationSpeed * movementX);
        rb.AddRelativeForce(new Vector2(0,1) * speed);
        Debug.Log(rb.rotation % 360);
        if (rb.rotation % 360 < 180)
        {
            enragedSpriteSR.flipX = true;  
		}
        else
        {
            enragedSpriteSR.flipX = false;  
		}
    }
       
    private void OnCollisionEnter2D(Collision2D col2d) 
    {
        if (col2d.collider.name == "Enraged Character") 
        {
            Physics2D.IgnoreCollision(col2d.collider, col2d.otherCollider);
        }
    }
}