using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathNavigator : MonoBehaviour {

    private Rigidbody m_carRigidBody;
    private int m_waypointIndex = 0;
    [SerializeField]
    private PathConfig m_pathConfig;
    [SerializeField]
    private int m_speed = 20;
    private int m_laps;

    private NavMeshAgent m_agent;

    private void Awake()
    {
        m_carRigidBody = GetComponent<Rigidbody>();
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.autoBraking = false;
    }

    private void Start()
    {
        GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        m_waypointIndex++;
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
        //Debug.Log("<color=#ffff00>Going to wapoint " + m_waypointIndex.ToString() + "</color>");
    }

    private void Update()
    {
        if (m_agent.remainingDistance < 13f)
        {
            //Debug.Log("<color=#ffff00>Going to next wapoint!</color>");
            GotoNextPoint();
        }
    }
}