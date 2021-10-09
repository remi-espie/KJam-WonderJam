using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject camera;
    [SerializeField] List<transform> tab;
    float smoothSpeed = 0.125f;
    private bool Player1End { get; }
    private bool Player2End { get; }


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
            
        }
    }


}
