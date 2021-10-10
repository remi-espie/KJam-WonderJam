using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    private int currentLvl { get; set; }
    private int maxLvlRich { get; set; }
    //private int[] collectable { get; set; }
    private int[] nbTries { get; set; }
    private int[] bestNbTries { get; set; }

    void Awake()
    {
        if (!Instance)
        {
            Load();
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*public void SavePlayer()
    {
        SaveSysteme.SavePlayer(this);
    }*/

    public void resetForNextLvl()
    {
        if(bestNbTries[currentLvl] > nbTries[currentLvl])
            bestNbTries[currentLvl] = nbTries[currentLvl];
        
        currentLvl++;
        
        if(maxLvlRich < currentLvl)
            MaxLvlRich = currentLvl;
        
        nbTries[currentLvl] = 0;
        
        Save();
    }

    /*public void LoadPlayer()
    {
        PlayerData data = SaveSysteme.LoadPlayer();

        currentLvl = data.CurrentLvl;
        maxLvlRich = data.MaxLvlRich;
        //collectable = data.Collectable;
        nbTries = data.NbTries;
        Debug.Log(data.ToString());
    }*/

    private GameManager()
    {
        currentLvl = 0;
        maxLvlRich = 1;
        //collectable[0] = 0;
        nbTries = new int[4];
        for(int i = 0; i < nbTries.Length; i++)
        {
            nbTries[i] = 0;
        }
        bestNbTries = new int[4];
        for (int i = 0; i < bestNbTries.Length; i++)
        {
            bestNbTries[i] = 0;
        }
    }
    private string SaveFilePath
    {
        get { return Application.persistentDataPath + "/playerInfo.sa"; }
    }

    public void DeleteSave()
    {
        try
        {
            File.Delete(SaveFilePath);
        }
        catch (IOException ex)
        {
            Debug.LogException(ex);
        }
    }
        public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/playerInfo.sa", FileMode.Create);

        PlayerData data = new PlayerData(this);
        data.CurrentLvl = GameManager.Instance.currentLvl;
        data.MaxLvlRich = GameManager.Instance.maxLvlRich;
        data.NbTries = GameManager.Instance.nbTries;
        data.BestNbTries = GameManager.Instance.bestNbTries;

        bf.Serialize(stream, data);
        stream.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.sa"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/playerInfo.sa", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(stream);

            GameManager.instance.currentLvl = data.CurrentLvl;
            GameManager.instance.maxLvlRich = data.MaxLvlRich;
            GameManager.instance.nbTries = data.NbTries;
            GameManager.instance.bestNbTries = data.BestNbTries;

            stream.Close();
        }
        else
        {
            Debug.Log("File does not exist.");
        }
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
    /*public int[] Collectable
    {
        get { return collectable; }
        set { collectable = value; }
    }*/
    public int[] NbTries
    {
        get { return nbTries; }
        set { nbTries = value; }
    }
    public int[] BestNbTries
    {
        get { return bestNbTries; }
        set { bestNbTries = value; }
    }

}
