using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathNavigator : MonoBehaviour {

    public float Progress { get { return (m_progress / (m_pathConfig.PathPoints.Length * 4f)); } }
    private int m_progress;

    private PlayerConfigJSON m_playerConfig;
    public PlayerConfigJSON PlayerConfig { get { return m_playerConfig; } set { m_playerConfig = value; } }

    [SerializeField]
    private PathConfig m_pathConfig;
    private int m_laps = 0;
    private int m_waypointIndex = 0;
    private NavMeshAgent m_agent;

    private void Awake()
    {
        m_progress = 0;
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.autoBraking = false;
    }

    public void StartRace()
    {
        m_agent.speed = (float)m_playerConfig.Velocity;
        m_agent.angularSpeed = (float)m_playerConfig.Velocity * 3f;
        m_agent.acceleration = (float)m_playerConfig.Velocity * 2f;
        GotoNextPoint();
    }
    
    private void GotoNextPoint()
    {
        m_waypointIndex++;
        m_progress = (m_laps * m_pathConfig.PathPoints.Length) + m_waypointIndex;
        if (m_waypointIndex < m_pathConfig.PathPoints.Length)
        {
            m_agent.destination = m_pathConfig.PathPoints[m_waypointIndex];
        }
        else
        {
            m_waypointIndex = 0;
            m_laps++;
            m_agent.destination = m_pathConfig.PathPoints[m_waypointIndex];
        }
        //Debug.Log("<color=#ffff00>Progress = " + (Progress*100f).ToString() + "</color>");
    }

    private void Update()
    {
        if (m_agent.remainingDistance < 13f)
        {
            GotoNextPoint();
        }
    }
}