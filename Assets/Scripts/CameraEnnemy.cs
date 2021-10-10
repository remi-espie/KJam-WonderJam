using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnnemy : MonoBehaviour
{
    public float visionLength;
    public float visionHeight;

    public Sprite activateSprite;
    public Sprite disableSprite;

    private GameObject vision;

    // Start is called before the first frame update
    void Start()
    {
        vision = transform.GetChild(0).gameObject;
        vision.transform.localScale = new Vector2(visionHeight, visionLength);
        vision.transform.localPosition = new Vector2(-visionHeight - 0.81f, -0.145f);
    }

    public void Activate()
    {
        GetComponent<SpriteRenderer>().sprite = disableSprite;
        vision.SetActive(false);
    }

    public void Desactivate()
    {
        GetComponent<SpriteRenderer>().sprite = activateSprite;
        vision.SetActive(true);
    }
}
