using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEndLevel : MonoBehaviour
{
    public string nextLevel;
    private int nbPlayers = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Contains("Player"))
        {
            collision.gameObject.SendMessage("EndSection");
            nbPlayers++;
            if(nbPlayers >= 2)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
