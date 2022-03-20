using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    private const float FADE_OPACITY = 0.4f;

    [SerializeField] private Image[] m_lifeImages = null;

    //======================================================================================================================================================================================================================

    #region Monobehaviour

    private void Start()
    {
        for (int i = 0; i < this.m_lifeImages.Length; ++i)
        {
            this.m_lifeImages[i].color = new Color(this.m_lifeImages[i].color.r, this.m_lifeImages[i].color.g, this.m_lifeImages[i].color.b, 1);
        }
    }

    private void OnEnable()
    {
        GameHandler.Instance.setLifeEvent.AddListener(this.SetLifeEvent);
    }

    private void OnDisable()
    {
        GameHandler.Instance.setLifeEvent.RemoveListener(this.SetLifeEvent);
    }

    #endregion Monobehaviour

    //======================================================================================================================================================================================================================

    #region Events

    private void SetLifeEvent(int lifeCount)
    {
        this.m_lifeImages[lifeCount].color = new Color(this.m_lifeImages[lifeCount].color.r, this.m_lifeImages[lifeCount].color.g, this.m_lifeImages[lifeCount].color.b, FADE_OPACITY);
    }

    #endregion Events

    //======================================================================================================================================================================================================================
}
