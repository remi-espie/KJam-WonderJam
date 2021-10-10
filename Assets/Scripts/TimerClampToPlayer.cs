using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerClampToPlayer : MonoBehaviour
{

    [SerializeField]
    private Text timerLabel;


    // Update is called once per frame
    void Update()
    {
        //float xPos = this.transform.position
        Vector2 timerPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        timerLabel.transform.position = timerPos;
    }
}
