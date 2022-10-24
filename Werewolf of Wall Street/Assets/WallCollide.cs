using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollide : MonoBehaviour
{
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Sprite cracked;
    public Sprite notCracked;
    public AudioSource crash;
    public string audioToFind = "Crash";
    bool hasCollided = false;
    void Start()
    {
       coll = GetComponent<BoxCollider2D>();
       sprite = GetComponent<SpriteRenderer>();
       crash = GameObject.Find(audioToFind).GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        if(collided.collider.name == "Enraged Character" && !hasCollided)
        {
            hasCollided = true;
            Meters.companyStanding -= 4;
            sprite.sprite = cracked;
            crash.Play();
		}
    }

    void Update()
    {
        if(Meters.playAgain == true)
        {
            hasCollided = false;
            sprite.sprite = notCracked; 
		}
	}
}
