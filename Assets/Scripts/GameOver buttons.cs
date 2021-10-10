using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverbuttons : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1.5f;

    public void Restart()
    {
        LoadNextScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelection()
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
