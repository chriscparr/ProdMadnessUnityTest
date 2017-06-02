﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRacePosition : MonoBehaviour {

    [SerializeField]
    private Sprite[] m_icons;

    [SerializeField]
    private Image m_iconDisplay;
    [SerializeField]
    private Text m_nameDisplay;
    [SerializeField]
    private Text m_rankDisplay;
    [SerializeField]
    private Image m_progressBarDisplay;
    
    public void SetRank(int a_rank)
    {
        m_rankDisplay.text = a_rank.ToString();
    }

    public void SetConfig(PathNavigator a_pathNav)
    {
        m_iconDisplay.sprite = m_icons[0];
        m_nameDisplay.text = a_pathNav.PlayerConfig.Name;
    }
}
