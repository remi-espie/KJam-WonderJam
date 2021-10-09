using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float visionLength;
    public float visionHeight;

    private GameObject vision;

    // Start is called before the first frame update
    void Start()
    {
        vision = transform.GetChild(0).gameObject;
        vision.transform.localScale = new Vector2(visionHeight, visionLength);
        vision.transform.localPosition = new Vector2(-visionHeight - 0.81f, -0.145f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
