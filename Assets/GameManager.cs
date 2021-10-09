using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int currentLvl { get; set; }
    private int maxLvlRich { get; set; }
    private int[] collectable { get; set; }
    private int[] nbTries { get; set; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SaveBySerialized()
    {
        Save save = createSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();

        FileStream fileStream = File.Create(Application.dataPath + "/DataBinary.txt");

        bf.Serialize(fileStream, save);

        fileStream.Close();
    }

    private Save createSaveGameObject()
    {
        Save save = new Save();

        save.Collectable[GameManager.Instance.CurrentLvl] = GameManager.Instance.Collectable[GameManager.Instance.CurrentLvl - 1];
        save.MaxLevelRich = GameManager.Instance.MaxLvlRich;
        save.nbTries[GameManager.Instance.CurrentLvl] = GameManager.Instance.NbTries[GameManager.Instance.CurrentLvl - 1];
        save.currentLvl = GameManager.Instance.CurrentLvl;

        return save;
    }

    private void LoadSave()
    {
        if (File.Exists(Application.dataPath + "/DataBinary.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream fileStream = File.Open(Application.dataPath + "/DataBinary.txt", FileMode.Open);

            Save save = bf.Deserialize(fileStream) as Save;

            GameManager.Instance.CurrentLvl = save.currentLvl;
            GameManager.Instance.MaxLvlRich = save.MaxLevelRich;
            GameManager.Instance.NbTries = save.nbTries;
            GameManager.Instance.Collectable = save.Collectable;
        }

    }

    private GameManager()
    {
        LoadSave();
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
