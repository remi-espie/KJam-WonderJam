using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEndLevel : MonoBehaviour
{
    public string nextLevel;
    private int nbPlayers = 0;

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
