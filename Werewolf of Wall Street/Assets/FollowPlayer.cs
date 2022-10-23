using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform cam;
    public Transform player;
    public int distance = 10;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam.position = new Vector3(player.position.x, player.position.y, -distance);
    }
}
