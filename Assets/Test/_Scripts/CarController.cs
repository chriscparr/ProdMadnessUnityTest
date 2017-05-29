using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    private Rigidbody m_carRigidBody;
    [SerializeField]
    private WheelCollider m_frontLeft;
    [SerializeField]
    private WheelCollider m_frontRight;
    [SerializeField]
    private WheelCollider m_rearLeft;
    [SerializeField]
    private WheelCollider m_rearRight;
    [SerializeField]
    private float m_enginePower = 150f;
   // [SerializeField]
    private float m_power;
    //[SerializeField]
    private float m_brake;
   // [SerializeField]
    private float m_steer;
    [SerializeField]
    private float m_steerMaxAngle = 50f;
    [SerializeField]
    private Vector3 m_centerOfMass;
    [SerializeField]
    private float m_brakingCoefficient = 0.5f;
    [SerializeField]
    private PathConfig m_pathConfig;
    [SerializeField]
    private MeshCollider m_carCollider;

    private void Awake()
    {
        m_carRigidBody = GetComponent<Rigidbody>();
        m_carRigidBody.centerOfMass = m_centerOfMass;
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_power = 0f;
        m_brake = 0f;
        m_steer = 0f;

        m_power = Input.GetAxis("Vertical") * m_enginePower * Time.deltaTime * 250f;
        m_steer = Input.GetAxis("Horizontal") * m_steerMaxAngle;

        m_frontLeft.steerAngle = m_steer;
        m_frontRight.steerAngle = m_steer;

        if (Input.GetKey(KeyCode.Space))
        {
            m_rearLeft.motorTorque = 0f;
            m_rearRight.motorTorque = 0f;
            m_brake = m_carRigidBody.mass * m_brakingCoefficient;
            m_frontLeft.brakeTorque = m_brake;
            m_frontRight.brakeTorque = m_brake;
            m_rearLeft.brakeTorque = m_brake;
            m_rearRight.brakeTorque = m_brake;
        }
        else
        {
            m_rearLeft.motorTorque = m_power;
            m_rearRight.motorTorque = m_power;
        }

    }
}
