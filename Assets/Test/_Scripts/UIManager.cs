using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private List<PathNavigator> m_players = new List<PathNavigator>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(m_players.Count > 1)
        {
            for (int i = 0; i < m_players.Count - 1; i++)
            {
                if(m_players[i].Progress < m_players[i+1].Progress)
                {
                    PathNavigator temp = m_players[i];
                    m_players[i] = m_players[i + 1];
                    m_players[i + 1] = temp;
                }
            }            
        }

        //Display stuff

	}
}
