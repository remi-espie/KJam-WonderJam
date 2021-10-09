using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager
{
    private static GameManager instance = new GameManager();

    private int currentLvl { get; set; }
    private int maxLvlRich { get; set; }
    private int[] collectable { get; set; }
    private int[] nbTries { get; set; }

    void Start()
    {
        //LoadPlayer();
    }
    public void SavePlayer()
    {
        SaveSysteme.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSysteme.LoadPlayer();

        currentLvl = data.CurrentLvl;
        maxLvlRich = data.MaxLvlRich;
        collectable = data.Collectable;
        nbTries = data.NbTries;
    }

    private GameManager()
    {
        LoadPlayer();
    }

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public int CurrentLvl
    {
        get { return currentLvl; }
        set { currentLvl = value; }
    }
    public int MaxLvlRich
    {
        get { return maxLvlRich; }
        set { maxLvlRich = value; }
    }
    public int[] Collectable
    {
        get { return collectable; }
        set { collectable = value; }
    }
    public int[] NbTries
    {
        get { return nbTries; }
        set { nbTries = value; }
    }

}
