using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeconWifi : MonoBehaviour
{
    public float signalIntensity;
    public bool needButton;

    public Sprite activeSprite;
    public Sprite disableSprite;

    private GameObject signal;

    void Awake()
    {
        signal = transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        signal.transform.localScale = new Vector2(signalIntensity, signalIntensity);
        signal.transform.localPosition = new Vector3(0, 0, 1);

        if(needButton)
        {
            signal.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = disableSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = activeSprite;
        }
    }

    public void Activate()
    {
        GetComponent<SpriteRenderer>().sprite = activeSprite;
        signal.SetActive(true);
    }

    public void Desactivate()
    {
        GetComponent<SpriteRenderer>().sprite = disableSprite;
        signal.SetActive(false);
    }
}
