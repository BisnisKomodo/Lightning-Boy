using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

class PlayerData
{
     public string email;
     public string password;
}



public class SaveLoad : MonoBehaviour
{
     private string path;

     void Start()
     {
          LoadJson();
          path = Application.persistentDataPath + "/save.lightning";
     }

     public void SaveJson()
     {
          //membuat data dummy
          PlayerData p1 = new PlayerData();
          p1.email = "lightning@binus.ac.id";
          p1.password = "tryagain";

          //convert data dari class menjadi string json
          string jsonP1 = JsonUtility.ToJson(p1);
          Debug.Log(jsonP1);

          //write file
          File.WriteAllText(path, jsonP1);
          // StreamWriter f = File.CreateText(path);
          // StreamWriter f = File.OpenWrite(Application.persistentDataPath);
          // f.WriteLine(jsonp1);
          // f.Close();
          Debug.Log($"File has been saved on {path}");
     }

     public void LoadJson()
     {
          if(!File.Exists(path))
          {
               return;
          }
          //baca file jsonstring
          string jsontext = File.ReadAllText(path);
          //konversi string json menjadi object (PlayerData)
          PlayerData pd = JsonUtility.FromJson<PlayerData>(jsontext);
          //tampilkan data pada object
          Debug.Log($"email : {pd.email}\n password : {pd.password}");
     }

     public void Save()
     {
        PlayerPrefs.SetFloat("bgm", 1f);
        PlayerPrefs.SetString("player name", "lightning boy");
        PlayerPrefs.SetInt("exp", 2001);

        DateTime today = DateTime.Now;
        Debug.Log(today.ToString());
        PlayerPrefs.SetString("Last Login", today.ToString());
     }
     public void Load()
     {
        float bgm  = PlayerPrefs.GetFloat("bgm");
        int exp = PlayerPrefs.GetInt("");
        string PlayerName = PlayerPrefs.GetString("player name", "lightning boy");

        Debug.Log($"{PlayerName} {exp} {bgm}");

        string lastLogin = PlayerPrefs.GetString("Last Login");
        DateTime lastDate = DateTime.Parse("lastlogin");
        Debug.Log($"{lastDate} Since last logged in");
     }
}
