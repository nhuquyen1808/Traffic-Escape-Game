using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int level;
    public List<Vector3> listCubePos;
}
public class SaveGameJson : MonoBehaviour
{
    public int levelEditing;
    public List<Vector3> listCubePos;
    public int indexLevel;
    public static SaveGameJson ins;
    private void Awake()
    {
        ins = this;
        levelEditing = PlayerPrefs.GetInt("indexLevel", 1);
    }
    public void UpdateData()
    {
        listCubePos.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            listCubePos.Add(transform.GetChild(i).localPosition);
        }
    }
    public void SaveData()
    {
        LevelData levelData = new LevelData();
        levelData.level = levelEditing;
        levelData.listCubePos = listCubePos;
        string data = JsonUtility.ToJson(levelData);
        File.WriteAllText($"Assets/Resources/DataLevel{levelData.level}.json", data);
    }
    public LevelData ReadData()
    {
        LevelData readData = new LevelData();
        string data = "";
#if UNITY_EDITOR
        // data = File.ReadAllText(($"Assets/Resources/DataLevel{levelEditing}.json"));
        data = File.ReadAllText(("Assets/Resources/DataLevel" + levelEditing + ".json"));
#else
        data = Resources.Load<TextAsset>($"DataLevel{levelEditing}").ToString();
#endif
        readData = JsonUtility.FromJson<LevelData>(data);
        listCubePos = readData.listCubePos;
        return readData;
    }
    
    
}