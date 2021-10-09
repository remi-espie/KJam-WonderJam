using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraController Camera;
    private bool Player1End { get; set; }
    private bool Player2End { get; set; }
    private int nbTries { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        Player1End = false;
        Player2End = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player1End && Player2End)
        {
            Camera.NextPos();
        }
    }


}
