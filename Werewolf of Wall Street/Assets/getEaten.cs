using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getEaten : MonoBehaviour
{   
    public GameObject thisGuy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.name == "Enraged Movement / Arrow")
        {
            thisGuy.SetActive(false);
		}
    }
}
