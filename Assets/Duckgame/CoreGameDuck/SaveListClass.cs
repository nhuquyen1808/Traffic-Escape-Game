using System.Collections.Generic;
using UnityEngine;
 [System.Serializable]
public class PlayerDt
    {
        public int id;
        public string name;
    }
namespace DevDuck
{
   
    public class SaveListClass : MonoBehaviour
    {

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                AddData();
                SaveData();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                LoadData();
            }
        }
        public List<PlayerDt> Players;
        public class DataPlayer
        {
            public List<PlayerDt> listPlayerSaved;
        }

        public void AddData()
        {
             Players.Add(new PlayerDt() {id = 0,name = "aaaaa" });
             Players.Add(new PlayerDt() {id = 1,name = "bbbbb" });
             Players.Add(new PlayerDt() {id = 2,name = "ccccc" });
             Players.Add(new PlayerDt() {id = 3,name = "ddddd" });
             Players.Add(new PlayerDt() {id = 4,name = "eeeee" });

        }

        void SaveData()
        {

            string playerStr = JsonUtility.ToJson(new DataPlayer { listPlayerSaved = Players });
            PlayerPrefs.SetString("PlayerData", playerStr);
        }
        void LoadData()
        {
            DataPlayer playerData = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("PlayerData"));
            Players = playerData.listPlayerSaved;

            for (int i = 0; i < Players.Count; i++)
            {
                Debug.Log(Players[i].name);
            }
        }
    }
}
