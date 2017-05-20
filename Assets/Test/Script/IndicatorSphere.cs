using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class IndicatorSphere : MonoBehaviour {

    public int Index { get; set; }
    public Vector3 Position { get { return gameObject.transform.position; } }

    public delegate void IndicatorEventHandler(int a_indicatorIndex);
    public event IndicatorEventHandler OnIndicatorMoved;

    private void Update()
    {
        if(transform.hasChanged)
        {
            //Debug.Log("<color=#00ff00>Things are changing round here. Is it me? I think so!</color>");
            if(OnIndicatorMoved != null)
            {
                OnIndicatorMoved(Index);
            }
            transform.hasChanged = false;
        }

    }

}