using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerClampToPlayer : MonoBehaviour
{

    [SerializeField]
    private Text timerTextLabel;
    Transform playerTransform;
    Transform timerTextLabelOverlay;
    void Start()
    {
        playerTransform = gameObject.transform;
        timerTextLabelOverlay = timerTextLabel.transform;
    }
    void LateUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(playerTransform.position);
        // add a tiny bit of height?
        screenPos.y += 2; // adjust as you see fit.
        timerTextLabelOverlay.position = screenPos;
    }
}
