using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/Test/Config/PathData.asset", menuName = "Create Path")]
public class PathConfig : ScriptableObject
{
    public Vector3[] PathPoints;
}
