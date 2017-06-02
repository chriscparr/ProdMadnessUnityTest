using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private PathNavigator m_pathNavPrefab;
    [SerializeField]
    private Camera m_followCam;

    //private PlayerConfigJSON[] m_playerConfigs;
    // public PlayerConfigJSON[] PlayerConfigs { get { return m_playerConfigs; }set { m_playerConfigs = value; } }

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

        Debug.Log("GameConfig - laps = " + m_gameData.GameConfiguration.lapsNumber.ToString() + " delay = " + m_gameData.GameConfiguration.playersInstantiationDelay.ToString());
        foreach (PlayerConfigJSON p in m_gameData.Players)
        {
            Debug.Log("Player - Name:" + p.Name + " Velocity:" + p.Velocity + " Color:" + p.Color + " Icon:" + p.Icon);
        }
    }
    

    private void Start ()
    {
        BeginRace();

    }

    private void BeginRace()
    {
        m_playerConfigs.Clear();
        for (int i = 0; i < 8; i++)
        {
            m_playerConfigs.Add(m_gameData.Players[Random.Range(0, m_gameData.Players.Length)]);
        }
        m_playerConfigs = m_playerConfigs.OrderByDescending(o => o.Velocity).ToList();
        //m_playerConfigs.Sort();

        int secs = m_gameData.GameConfiguration.playersInstantiationDelay / 1000;
        
        for (int i = 0; i < 8; i++)
        {
            Invoke("SpawnCar", secs * i);
        }
        //UnityStandardAssets.Utility.SmoothFollow camFollow = m_followCam.GetComponent<UnityStandardAssets.Utility.SmoothFollow>();
        //camFollow.target = m_racers[0].transform;
    }

    private void SpawnCar()
    {
        m_racers.Add(Instantiate<PathNavigator>(m_pathNavPrefab));
        /*
        PlayerConfigJSON dummyConfig = new PlayerConfigJSON();
        dummyConfig.Name = "Test_" + (m_racers.Count - 1).ToString();
        dummyConfig.Velocity = Random.Range(20, 40);
        m_racers[m_racers.Count - 1].PlayerConfig = dummyConfig;
        */
        m_racers[m_racers.Count - 1].PlayerConfig = m_playerConfigs[m_racers.Count - 1];
        m_racers[m_racers.Count - 1].StartRace();
        Debug.Log("<color=#44ff00>Racer " + m_racers[m_racers.Count - 1].PlayerConfig.Name + " GO!</color>");
        if(m_racers.Count == 1)
        {
            UnityStandardAssets.Utility.SmoothFollow camFollow = m_followCam.GetComponent<UnityStandardAssets.Utility.SmoothFollow>();
            camFollow.target = m_racers[m_racers.Count - 1].transform;
        }
    }
	
	// Update is called once per frame
	private void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCar();
        }
	}
}
