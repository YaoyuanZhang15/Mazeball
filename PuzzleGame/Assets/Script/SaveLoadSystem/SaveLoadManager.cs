using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    public int LoadLevel;
    public int currLevel;
    

    public readonly int maxLevel = 2;
    public string lastSaveTime;

    public List<int> levelCollection;

    string keyString;

    private void Awake()
    {
        LoadLevel = 0;
        
        LoadAllData();
    }

    public void LoadAllData()
    {
        keyString = "PlayerLevel";
        currLevel = PlayerPrefs.GetInt(keyString, 0);

        for (int i = 0; i < levelCollection.Count; i++)
        {
            keyString = "Collection" + i;
            levelCollection[i] = PlayerPrefs.GetInt(keyString, 0);
        }

        keyString = "LastSaveTime";
        lastSaveTime = PlayerPrefs.GetString(keyString, "New!");
        
    }

    public void ResetAllData()
    {
        //keyString = "PlayerLevel";
        LoadLevel = 0;
        currLevel = 0;

        for (int i = 0; i < levelCollection.Count; i++)
        {
            //keyString = "Collection" + i;
            levelCollection[i] = 0;
        }

        SaveAllData();

    }

    public void SaveAllData()
    {
        keyString = "PlayerLevel";
        PlayerPrefs.SetInt(keyString, currLevel);


        for (int i = 0; i < levelCollection.Count; i++)
        {
            keyString = "Collection" + i;

            PlayerPrefs.SetInt(keyString, levelCollection[i]);
        }

        SetLastSaveTime();

    }

    public void SetGameLevel(int i)
    {
        if (i < maxLevel)
        {
            currLevel = i;
        }
        else
        {
            currLevel = maxLevel - 1;
        }
        keyString = "PlayerLevel";
        PlayerPrefs.SetInt(keyString, currLevel);
    }

    public void SetLastSaveTime()
    {
        lastSaveTime = System.DateTime.Now.ToString();
        keyString = "LastSaveTime";
        PlayerPrefs.SetString(keyString, lastSaveTime);
    }

    public void UpdateCurrLevelCollection(int i)
    {
        if (levelCollection[LoadLevel] < i)
        {
            SetLevelCollection(LoadLevel, i);
        }
        
    }

    private void SetLevelCollection(int index, int value)
    {
        levelCollection[index] = value;

        keyString = "Collection" + index;
        PlayerPrefs.SetInt(keyString, value);
    }

    



    


}
