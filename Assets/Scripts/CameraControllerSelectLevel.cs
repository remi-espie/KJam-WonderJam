using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class CameraControllerSelectLevel : MonoBehaviour
{
    [SerializeField] List<GameObject> tab;
    [SerializeField] List<GameObject> stairs;
    [SerializeField] List<GameObject> Lock;
    [SerializeField] List<GameObject> nbTriesText;
    [SerializeField] List<Sprite> BouttonsAscensseur;
    [SerializeField] SpriteRenderer SpriteButton;
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1f;
    //public GameObject gameManager;
    [SerializeField] Vector3 offset;

    int index = 0;
    float smoothSpeed = 2.5f;
    bool camera_move_enabled = false;
    Vector3 desiredPosition;

    private void Start()
    {
        tab[index].GetComponent<Animator>().SetBool("isSelected", true);
        Debug.Log("MaxLvlRich "+GameManager.Instance.MaxLvlRich);
        Debug.Log("CurrentLvl "+GameManager.Instance.CurrentLvl);
        //Debug.Log("Nbtries "+GameManager.Instance.NbTries);
        int nbLevel = GameManager.Instance.MaxLvlRich;
        int nbStairs = GameManager.Instance.MaxLvlRich - 1;
        for(int i = 0; i < tab.Count; i++)
        {
            int[] nbTriesLvl = GameManager.Instance.BestNbTries;
            nbTriesText[i].GetComponent<TextMeshPro>().text = nbTriesLvl[i].ToString()+" Tries";
        }
        for (int i = 0; i < nbStairs; i++)
        {
            stairs[i].gameObject.SetActive(true);
        }
        for(int i=0; i < nbLevel; i++)
        {
            Lock[i].gameObject.SetActive(false);
            nbTriesText[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(index+1 < tab.Count-1 && index+1 < GameManager.Instance.MaxLvlRich)
            {
                NextPos();
                SpriteButton.sprite = BouttonsAscensseur[1];
            }
                
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            SpriteButton.sprite = BouttonsAscensseur[0];
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (index - 1 >= 0)
            {
                PreviousPos();
                SpriteButton.sprite = BouttonsAscensseur[2];
            }
            
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            SpriteButton.sprite = BouttonsAscensseur[0];
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            //save data player
            GameManager.Instance.CurrentLvl++;
            GameManager.Instance.NbTries[GameManager.Instance.CurrentLvl] = 0;
            //GameManager.Instance.Collectable[GameManager.Instance.CurrentLvl] = 0;
            int numLvl = index + 1;
            string levelSelected = "Level" + numLvl;
            SceneManager.LoadScene(levelSelected);
        }

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


    private void FixedUpdate()
    {
        if (camera_move_enabled)
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        if (transform.position == desiredPosition)
            camera_move_enabled = false;
    }

    public void NextPos()
    {
        tab[index].GetComponent<Animator>().SetBool("isSelected", false);
        index++;
        if (index > tab.Count - 1)
        {
            index = tab.Count - 1;
        }
        else
        {
            desiredPosition = tab[index].transform.position + offset;
            desiredPosition.x = 0;
            tab[index].GetComponent<Animator>().SetBool("isSelected", true);
            //Debug.Log(desiredPosition);
            camera_move_enabled = true;
        }

    }

    public void PreviousPos()
    {
        tab[index].GetComponent<Animator>().SetBool("isSelected", false);
        index--;
        if (index < 0)
        {
            index = 0;
            //Debug.Log("Change scene");
        }
        else
        {
            desiredPosition = tab[index].transform.position + offset;
            desiredPosition.x = 0;
            tab[index].GetComponent<Animator>().SetBool("isSelected", true);
            //Debug.Log(desiredPosition);
            camera_move_enabled = true;
        }

    }

}
