using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getEaten : MonoBehaviour
{   
    public GameObject thisGuy;
    int randomVal;
    int randomX;
    int randomY;
    bool isInCollision = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public BoxCollider2D actualBc;
    private BoxCollider2D bc;
    private Animator anim;
    AudioSource audioData;
    public float speed = 1f;
    int randomDecision = 0;
    private float timeElapsed = 0f;
    public float respawnTime = 5f;
    public GameObject respawner;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioData = GameObject.Find("Scream").GetComponent<AudioSource>();
        int randomVal = Random.Range(0, 4);
        switch (randomVal)
        {
        case 0:
            randomX = 1;
            randomY = 1;
            break;
        case 1:
            randomX = -1;
            randomY = 1;
            break;
        case 2:
            randomX = -1;
            randomY = -1;
            break;
        case 3:
            randomX = 1;
            randomY = -1;
            break;
       	}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Enraged Character")
        {
            audioData.Play();
            Object.Instantiate(respawner, thisGuy.transform.position, Quaternion.identity);
            GameObject.Destroy(thisGuy);
		}
        else if(other.name != "Player (Normal)")
        {   
            if (!isInCollision)
            {
                randomY *= -1;
                isInCollision = true;
            }
		}
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.name != "Player (Normal)")
        {
            isInCollision = false;
		}
	}
    void FixedUpdate()
    {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= 2f)
            {
                timeElapsed = 0f;
                randomDecision = Random.Range(0, 3);
	        }
            if(randomDecision == 0)
            {
                anim.SetBool("IsWalking", true);
                if(randomX == -1)
                {
                    sr.flipX = true;
		        }
                else
                {
                    sr.flipX = false;  
		        }
                rb.AddForce(new Vector2(randomX, randomY) * speed);
            }
            else if(randomDecision == 1)
            {
                anim.SetBool("IsWalking", true);
                if(randomX == -1)
                {
                    sr.flipX = false;
		        }
                else
                {
                    sr.flipX = true;  
		        }
                rb.AddForce(new Vector2(-randomX, randomY) * speed);
		    }
            else
            {
                anim.SetBool("IsWalking", false);  
		    }
    }
}
