using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private int currentLvl { get; set; }
    private int maxLvlRich { get; set; }
    private int[] collectable { get; set; }
    private int[] nbTries { get; set; }

    public PlayerData(GameManager gameManager){
        currentLvl = gameManager.CurrentLvl;
        maxLvlRich = gameManager.MaxLvlRich;
        collectable = gameManager.Collectable;
        nbTries = gameManager.NbTries;
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
        set { nbTries= value; }
    }
}
