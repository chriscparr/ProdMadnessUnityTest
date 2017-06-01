using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private PathNavigator m_pathNavPrefab;

    private PlayerConfigJSON[] m_playerConfigs;
    public PlayerConfigJSON[] PlayerConfigs { get { return m_playerConfigs; }set { m_playerConfigs = value; } }

    private List<PathNavigator> m_racers = new List<PathNavigator>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_racers.Add(Instantiate<PathNavigator>(m_pathNavPrefab));
            PlayerConfigJSON dummyConfig = new PlayerConfigJSON();
            dummyConfig.Name = "Test_" + (m_racers.Count - 1).ToString();
            dummyConfig.Velocity = Random.Range(20, 40);
            m_racers[m_racers.Count - 1].PlayerConfig = dummyConfig;
            Debug.Log("<color=#44ff00>Racer " + m_racers[m_racers.Count - 1].PlayerConfig.Name + " GO!</color>");
        }
	}
}
