using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            transform.Translate(0f, 1f, 0f);  
        }
        if (Input.GetKeyDown("s"))
        {
            transform.Translate(0f, -1f, 0f);  
        }
        if (Input.GetKeyDown("d"))
        {
            transform.Translate(1f, 0f, 0f);  
        }
        if (Input.GetKeyDown("q"))
        {
            transform.Translate(-1f, 0f, 0f);  
        }
    }
}
