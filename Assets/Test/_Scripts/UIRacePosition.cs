using System.Collections;
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

    private Color m_configColor;
    private int m_progressBarInitWidth = 150;
    private PathNavigator m_pathNav;
    public void SetRank(int a_rank)
    {
        m_rankDisplay.text = a_rank.ToString();
    }

    public void SetConfig(PathNavigator a_pathNav)
    {
        m_pathNav = a_pathNav;
        m_iconDisplay.sprite = m_icons[0];
        m_nameDisplay.text = m_pathNav.PlayerConfig.Name;
        ColorUtility.TryParseHtmlString(m_pathNav.PlayerConfig.Color, out m_configColor);
        m_nameDisplay.color = m_configColor;
        m_rankDisplay.color = m_configColor;

    }

    private void Update()
    {
        m_progressBarDisplay.rectTransform.localScale = new Vector3(m_pathNav.Progress, 1f, 1f);

       // m_pathNav.Progress
    }
}
