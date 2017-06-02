using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private UIRacePosition[] m_positionSlots;
    [SerializeField]
    private GameObject m_gameOverPanel;

    public bool GameOverPanelActive { get { return m_gameOverPanel.activeSelf; } set { m_gameOverPanel.SetActive(value); } }

    private List<PathNavigator> m_players = new List<PathNavigator>();
    private bool m_isPlaying = false;
    public void AddNewPlayer(PathNavigator a_pathNav)
    {
        m_players.Add(a_pathNav);
    }

	public void StartRace ()
    {
        m_isPlaying = true;
    }

    public void EndRace()
    {
        if(m_isPlaying)
        {
            m_gameOverPanel.SetActive(true);
            m_isPlaying = false;            
        }
    }
	
	private void Update ()
    {
        if(m_players.Count > 1 && m_isPlaying)
        {
            for (int i = 0; i < m_players.Count - 1; i++)
            {
                if(m_players[i].Progress >= 1f)
                {
                    EndRace();
                }
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
