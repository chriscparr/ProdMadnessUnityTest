using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNavigator : MonoBehaviour {

    private Rigidbody m_carRigidBody;
    private int m_waypointIndex = 0;
    [SerializeField]
    private PathConfig m_pathConfig;
    [SerializeField]
    private int m_speed = 20;
    private int m_laps = 4;

    private void Awake()
    {
        m_carRigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
		if(m_laps > 0)
        {
            if(m_waypointIndex < m_pathConfig.PathPoints.Length)
            {
                //turn + move
                transform.forward = Vector3.RotateTowards(transform.forward, m_pathConfig.PathPoints[m_waypointIndex] - transform.position, m_speed * Time.deltaTime, 0.0f);
                transform.position = Vector3.MoveTowards(transform.position, m_pathConfig.PathPoints[m_waypointIndex], m_speed * Time.deltaTime);

                if (transform.position == m_pathConfig.PathPoints[m_waypointIndex])
                {
                    m_waypointIndex++;
                }
            }
            else
            {
                m_waypointIndex = 0;
                m_laps--;
            }

        }


	}
}
