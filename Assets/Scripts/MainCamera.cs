using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour
{
    private static MainCamera INSTANCE;
    private Camera cam;
    public bool alarm;

    public Canvas Canvas;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        INSTANCE = this;
    }

    public static MainCamera GetInstance()
    {
        return INSTANCE;
    }

    public void StartAlarm()
    {
        if(!alarm)
        {
            alarm = true;
            StartCoroutine(Alarm());
        }
    }

    public void StopAlarm()
    {
        if(alarm)
        {
            alarm = false;
        }
    }

    IEnumerator Alarm()
    {
        while(alarm)
        {
            if(alarm)
            {
                Canvas.GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                yield return new WaitForSecondsRealtime(0.5f);
            }

            Canvas.GetComponent<RawImage>().color = new Color(255, 255, 255, 0);
            yield return new WaitForSecondsRealtime(0.5f);
        }

        yield return null;
    }
}
