using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathConfig))]
public class PathConfigEditor : Editor {
    [SerializeField]
    private IndicatorSphere m_indicatorPrefab;
    private GameObject m_indicatorParent;
    private List<IndicatorSphere> m_pathMarkers;

    public override void OnInspectorGUI()
    {
        m_pathMarkers = new List<IndicatorSphere>();
        m_indicatorParent = new GameObject("PathIndicators");

        DrawDefaultInspector();
        EditorGUILayout.LabelField("Some Label");
        if (GUILayout.Button("Spawn New Waypoint"))
        {
            Instantiate<IndicatorSphere>(m_indicatorPrefab, m_indicatorParent.transform);
            //pathBuilder.SpawnWaypoint();
        }
    }
}