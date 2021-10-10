using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnnemy : MonoBehaviour
{
    public Sprite activateSprite;
    public Sprite disableSprite;

    private GameObject vision;

    // Start is called before the first frame update
    void Start()
    {
        vision = transform.GetChild(0).gameObject;
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
