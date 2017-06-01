using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private PathNavigator m_pathNavPrefab;


    //public CarController m_carController;
    private List<PathNavigator> m_racers = new List<PathNavigator>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_racers.Add(Instantiate<PathNavigator>(m_pathNavPrefab));
            Debug.Log("<color=#44ff00>Racer no " + m_racers.Count.ToString() + " GO!</color>");
        }
	}
}
