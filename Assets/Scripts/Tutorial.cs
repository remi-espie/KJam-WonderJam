using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject text;
    

    public SpriteRenderer ascenseur;
    public Sprite upButton;
    public Sprite downButton;
    public Sprite stayButton;
    
    private RectTransform textBox;
    private void Start()
    {
        textBox = text.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ascenseur.sprite = upButton;
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ascenseur.sprite = downButton;
            
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 pos = textBox.transform.position;
            if (pos.y>-3)
            {
                textBox.transform.position = pos + new Vector3(0, -0.1f, 0);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 pos = textBox.transform.position;print(pos);
            if (pos.y<1.7)
            {
                textBox.transform.position = pos + new Vector3(0, 0.1f, 0);
            }
        }
        
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            ascenseur.sprite = stayButton;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            ascenseur.sprite = stayButton;
        }
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void play()
    {
        SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
    }
}
