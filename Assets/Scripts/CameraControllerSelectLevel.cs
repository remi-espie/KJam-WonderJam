using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControllerSelectLevel : MonoBehaviour
{
    [SerializeField] List<GameObject> tab;
    [SerializeField] Vector3 offset;

    int index = 0;
    float smoothSpeed = 2.5f;
    bool camera_move_enabled = false;
    Vector3 desiredPosition;

    private void Start()
    {
        tab[index].GetComponent<Animator>().SetBool("isSelected", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(index+1 < tab.Count-1 && index+1 <= PlayerPrefs.GetInt("MaxLevelRich"))
                NextPos();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (index - 1 > 0 )
                PreviousPos();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            //save data player

            string levelSelected = "Level" + index+1;
            SceneManager.LoadScene(levelSelected);
        }

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
            //Debug.Log("Change scene");
        }
        else
        {
            desiredPosition = tab[index].transform.position + offset;
            desiredPosition.x = 0;
            tab[index].GetComponent<Animator>().SetBool("isSelected", true);
            Debug.Log(desiredPosition);
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
            Debug.Log(desiredPosition);
            camera_move_enabled = true;
        }

    }
}
