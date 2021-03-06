﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private PathNavigator m_pathNavPrefab;
    [SerializeField]
    private Camera m_followCam;
    [SerializeField]
    private UIManager m_uiManager;

    private List<PathNavigator> m_racers = new List<PathNavigator>();
    private DataJSON m_gameData;
    private List<PlayerConfigJSON> m_playerConfigs = new List<PlayerConfigJSON>();
    private string m_jsonData;
    private string m_path = "Assets/StreamingAssets/Data.txt";

    private void Awake()
    {
        StreamReader reader = new StreamReader(m_path, true);
        m_jsonData = reader.ReadToEnd();
        reader.Close();

        m_gameData = JsonUtility.FromJson<DataJSON>(m_jsonData);
    }

    public void NewRace()
    {
        foreach(PathNavigator p in m_racers)
        {
            Destroy(p.gameObject);
        }
        m_racers.Clear();
        BeginRace();
        m_uiManager.StartRace();
    }

    private void BeginRace()
    {
        m_playerConfigs.Clear();
        for (int i = 0; i < 8; i++)
        {
            m_playerConfigs.Add(m_gameData.Players[Random.Range(0, m_gameData.Players.Length)]);
        }
        m_playerConfigs = m_playerConfigs.OrderBy(o => o.Velocity).ToList();

        for(int i = 0; i < m_playerConfigs.Count; i++)
        {
            Debug.Log("player " + i.ToString() + " , speed : " + m_playerConfigs[i].Velocity);
        }
       
        int secs = m_gameData.GameConfiguration.playersInstantiationDelay / 1000;
        
        for (int i = 0; i < 8; i++)
        {
            Invoke("SpawnCar", secs * i);
        }
    }

    private void SpawnCar()
    {
        m_racers.Add(Instantiate<PathNavigator>(m_pathNavPrefab));

        m_racers[m_racers.Count - 1].PlayerConfig = m_playerConfigs[m_racers.Count - 1];
        m_uiManager.AddNewPlayer(m_racers[m_racers.Count - 1]);
        m_racers[m_racers.Count - 1].StartRace();
        //sDebug.Log("<color=#44ff00>Racer " + m_racers[m_racers.Count - 1].PlayerConfig.Name + " GO!</color>");
                
        UnityStandardAssets.Utility.SmoothFollow camFollow = m_followCam.GetComponent<UnityStandardAssets.Utility.SmoothFollow>();
        camFollow.target = m_racers[m_racers.Count - 1].transform;
    }	
}
