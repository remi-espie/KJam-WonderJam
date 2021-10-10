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

    IEnumerator KillWaiter()
    {
        //yield on a new YieldInstruction that waits for 2.5 seconds.
        yield return new WaitForSecondsRealtime(2.5f);

        //After we have waited 5 seconds print the time again.
        Death();
    }

    public static void Death()
    {
        SceneManager.LoadScene("LevelOne");
        //SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        print("hitbox touchée");

        if (collider2D.tag == "Player" || collider2D.tag == "Player1" || collider2D.tag == "Player2")
        {
            print("hitbox touchée par PLAYER");
            Time.timeScale = 0.0f;
            StartCoroutine(KillWaiter());
            //SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

        }

        if (collider2D.tag == "Guard")
        {
            print("hitbox touchée par GUARD");

        }
    }
}
