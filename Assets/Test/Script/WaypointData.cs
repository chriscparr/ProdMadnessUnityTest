using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaypointData", menuName = "Define Waypoints")]
public class WaypointData : ScriptableObject {

    public List<Transform> Waypoints;

}