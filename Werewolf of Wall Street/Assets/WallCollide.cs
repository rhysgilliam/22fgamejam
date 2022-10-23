using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollide : MonoBehaviour
{
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Sprite cracked;
    void Start()
    {
       coll = GetComponent<BoxCollider2D>();
       sprite = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        if(collided.collider.name == "Enraged Character")
        {
            sprite.sprite = cracked;
		}
    }
}
