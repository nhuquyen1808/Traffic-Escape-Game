using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public static class CubeDataManager
{
    public static LevelData data;
}
#if UNITY_EDITOR
[CustomEditor(typeof(SaveGameJson), true)]
public class SetMapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        SaveGameJson manageCube = (SaveGameJson)target;
        if (GUILayout.Button("Update Data"))
        {
            manageCube.UpdateData();
        }
        if (GUILayout.Button("Save Data"))
        {
            manageCube.SaveData();
        }
        if (GUILayout.Button("Read Data"))
        {
            CubeDataManager.data = manageCube.ReadData();
            Debug.Log(CubeDataManager.data.listCubePos);
            Debug.Log("3");
        }
    }
}
#endif