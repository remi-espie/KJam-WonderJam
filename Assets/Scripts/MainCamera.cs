using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private static MainCamera INSTANCE;
    private Camera cam;
    private Color camColor;
    public bool alarm;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        camColor = cam.backgroundColor;

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
            StopCoroutine(Alarm());
            cam.backgroundColor = camColor;
        }
    }

    IEnumerator Alarm()
    {
        while(alarm)
        {
            cam.backgroundColor = Color.red;
            yield return new WaitForSecondsRealtime(0.5f);

            cam.backgroundColor = camColor;
            yield return new WaitForSecondsRealtime(0.5f);
        }

        yield return null;
    }
}
