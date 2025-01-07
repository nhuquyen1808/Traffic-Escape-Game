using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DevDuck
{
    public static class SaveGame
    {
        public static int[] ArraySaved;

        public static int[] ArrayAdd;
        public static List<int> listID = new List<int>();
        public static void SaveArrayToPlayerPrefs()
        {
            ArraySaved = listID.ToArray();
            string arrayString = string.Join(",", ArraySaved);
            PlayerPrefs.SetString("MyArray", arrayString);
        }

        public static void AddListIdToArray(List<int> idAdded)
        {
            LoadArrayFromPlayerPrefs();
            List<int> list = ArraySaved.ToList();
            for (int i = 0; i < idAdded.Count; i++)
            {
                if (!listID.Contains(idAdded[i])) { list.Add(idAdded[i]); }
            }
            ArraySaved = list.ToArray();
            string arrayString = string.Join(",", ArraySaved);
            PlayerPrefs.SetString("MyArray", arrayString);
        }
        public static void AddElementToArray(int elementAdded)
        {
            LoadArrayFromPlayerPrefs();
            List<int> list = ArraySaved.ToList();
            if (!list.Contains(elementAdded))
            {
                list.Add(elementAdded);
            }
            ArraySaved = list.ToArray();
            string arrayString = string.Join(",", ArraySaved);
            PlayerPrefs.SetString("MyArray", arrayString);
        }
        public static void AddListElementToArray(List<int> listAdded)
        {
            LoadArrayAddFromPlayerPrefs();
            List<int> newArray = ArrayAdd.ToList();
            for (int i = 0; i < listAdded.Count; i++)
            {
                if (!newArray.Contains(listAdded[i]))
                {
                    newArray.Add(listAdded[i]);
                }
            }
            ArrayAdd = newArray.ToArray();
            string arrayString = string.Join(",", ArrayAdd);
            PlayerPrefs.SetString("MyArray", arrayString);
        }
        public static void LoadArrayFromPlayerPrefs()
        {
            string arrayString = PlayerPrefs.GetString("MyArray", "");
            if (!string.IsNullOrEmpty(arrayString))
            {
                ArraySaved = System.Array.ConvertAll(arrayString.Split(','), int.Parse);
            }
            else
            {
                ArraySaved = new int[0];
            }

        }
        public static void LoadArrayAddFromPlayerPrefs()
        {
            string arrayString = PlayerPrefs.GetString("MyArray", "");
            if (!string.IsNullOrEmpty(arrayString))
            {
                ArrayAdd = System.Array.ConvertAll(arrayString.Split(','), int.Parse);
            }
            else
            {
                ArrayAdd = new int[0];
            }

        }
        public static void SaveInt(string str, int a)
        {
            PlayerPrefs.SetInt(str, a);
        }
        public static void SaveFloat(string str, float a)
        {
            PlayerPrefs.SetFloat(str, a);
        }
        public static void DeleteKey(string str)
        {
            PlayerPrefs.DeleteKey(str);
        }
    }
}
