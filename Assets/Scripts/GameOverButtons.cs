using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOverButtons : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelSelect();
        }
    }

    public void Restart()
    {
        LoadNextScene(SceneManager.GetActiveScene().name);
    }
    public void LevelSelect()
    {
        LoadNextScene("LevelSelection");
    }

    public void LoadNextScene(string nextLevel)
    {
        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(string nextLevel)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(nextLevel);
    }
}
