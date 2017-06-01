using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerConfigJSON : IComparable {
    public string Name;
    public int Velocity;
    public string Color;
    public string Icon;
    public int CompareTo(object obj)
    {
        return Velocity.CompareTo(obj);
    }
}
