using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private UIRacePosition[] m_positionSlots;

    private List<PathNavigator> m_players = new List<PathNavigator>();

    public void AddNewPlayer(PathNavigator a_pathNav)
    {
        m_players.Add(a_pathNav);
    }

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
        for(int i = 0; i < m_positionSlots.Length; i++)
        {
            if(i == m_players.Count)
            {
                break;
            }
            m_positionSlots[i].SetRank(i);
            m_positionSlots[i].SetConfig(m_players[i]);
        }
	}
}
