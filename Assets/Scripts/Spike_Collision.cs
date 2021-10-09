using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike_Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {

        if (collider2D.tag == "Player" || collider2D.tag == "Player1" || collider2D.tag == "Player2")
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

        }
    }
}
