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
    private PathNavigator m_pathNav;
    public void SetRank(int a_rank)
    {
        m_rankDisplay.text = (a_rank + 1).ToString();
    }

    public void SetConfig(PathNavigator a_pathNav)
    {
        m_pathNav = a_pathNav;
        m_iconDisplay.sprite = m_icons[0];
        m_nameDisplay.text = m_pathNav.PlayerConfig.Name;
        ColorUtility.TryParseHtmlString(m_pathNav.PlayerConfig.Color, out m_configColor);
        m_nameDisplay.color = m_configColor;
        m_rankDisplay.color = m_configColor;
        m_progressBarDisplay.color = m_configColor;

        switch(m_pathNav.PlayerConfig.Icon)
        {
            case "http://image0.flaticon.com/icons/png/128/70/70078.png":
                m_iconDisplay.sprite = m_icons[1];
                break;
            case "http://downloadicons.net/sites/default/files/random-user-icon-15571.png":
                m_iconDisplay.sprite = m_icons[4];
                break;
            case "http://icons.iconarchive.com/icons/iconka/meow/256/cat-purr-icon.png":
                m_iconDisplay.sprite = m_icons[3];
                break;
            case "http://www.freeiconspng.com/uploads/cat-icon-9.png":
                m_iconDisplay.sprite = m_icons[2];
                break;
            case "http://www.sucaijiayuan.com/uploads/file/content/2015/03/550bc3fb48342.png":
                m_iconDisplay.sprite = m_icons[0];
                break;
            default:
                m_iconDisplay.sprite = m_icons[0];
                break;
        }
    }

    private void Update()
    {
        if(m_pathNav != null)
        {
            m_progressBarDisplay.rectTransform.localScale = new Vector3(m_pathNav.Progress, 1f, 1f);
        }
    }
}
