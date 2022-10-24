using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    CanvasGroup cg;
    float timeElapsed;
    public float duration = 0.13f;
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
       cg = GetComponent<CanvasGroup>(); 
       go = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= duration)
        {
           Destroy(cg.gameObject);
		}
    }
}
