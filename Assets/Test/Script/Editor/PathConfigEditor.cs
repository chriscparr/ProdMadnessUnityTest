using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathConfig))]
public class PathConfigEditor : Editor {
    [SerializeField]
    private IndicatorSphere m_indicatorPrefab;

    private GameObject m_indicatorParent;
    private PathConfig m_pathConfig;

    
    public List<IndicatorSphere> m_pathMarkers = new List<IndicatorSphere>();

    private void OnEnable()
    {
        m_pathConfig = (PathConfig)target;
        if (GameObject.Find("IndicatorParent") != null)
        {
            m_indicatorParent = GameObject.Find("IndicatorParent");
        }
        else
        {
            m_indicatorParent = new GameObject("IndicatorParent");
        }
        CreatePathFromScriptableObject();
    }

    /*
    private void OnDestroy()
    {
        RemoveIndicators();
        DestroyImmediate(m_indicatorParent);
    }
    */

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Spawn new waypoint"))
        {
            IndicatorSphere test;
            test = Instantiate(m_indicatorPrefab, m_indicatorParent.transform);
            if (m_pathMarkers.Count > 1)
            {
                Vector3 next = m_pathMarkers[m_pathMarkers.Count - 1].transform.position - m_pathMarkers[m_pathMarkers.Count - 2].transform.position;
                test.transform.position = m_pathMarkers[m_pathMarkers.Count - 1].transform.position + next;
            }
            else
            {
                test.transform.position = Vector3.one;
            }
            m_pathMarkers.Add(test);
            SavePathToScriptableObject();

        }
        if (GUILayout.Button("Remove last waypoint"))
        {
            if(m_pathMarkers.Count > 0)
            {
                DestroyImmediate(m_pathMarkers[m_pathMarkers.Count - 1].gameObject);
                m_pathMarkers.RemoveAt(m_pathMarkers.Count - 1);
                SavePathToScriptableObject();
            }
        }
        if (GUILayout.Button("Clear all waypoints"))
        {
            RemoveIndicators();
        }
        /*
        if (GUILayout.Button("BIG_BUTTON"))
        {
            Debug.Log("<color=#ffff00>Big button pressed!</color>");
            IndicatorSphere test;
            test = Instantiate(m_indicatorPrefab);
        }
        */
    }

    private void SavePathToScriptableObject()
    {
        Vector3[] configPathPoints = new Vector3[m_pathMarkers.Count];
        for(int i = 0; i < m_pathMarkers.Count; i++)
        {
            configPathPoints[i] = m_pathMarkers[i].transform.position;
        }
        m_pathConfig.PathPoints = configPathPoints;
    }
    
    private void CreatePathFromScriptableObject()
    {
        if (m_pathConfig.PathPoints.Length > 0)
        {
            RemoveIndicators();
            for (int i = 0; i < m_pathConfig.PathPoints.Length; i++)
            {
                m_pathMarkers.Add(Instantiate(m_indicatorPrefab, m_indicatorParent.transform));
                m_pathMarkers[i].transform.position = m_pathConfig.PathPoints[i];
            }
        }
    }

    private void RemoveIndicators()
    {
       while(m_indicatorParent.transform.childCount > 0)
        {
            DestroyImmediate(m_indicatorParent.transform.GetChild(0).gameObject);
        }
        m_pathMarkers.Clear();
    }
    
}