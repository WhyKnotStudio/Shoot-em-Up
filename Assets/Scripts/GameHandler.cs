using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SetLifeEvent : UnityEvent<int> { }

public class GameHandler : MonoBehaviour
{
    // Singleton
    private static GameHandler m_instance;
    public static GameHandler Instance { get { return m_instance; } }

    private const int MAX_LIFE_COUNT = 3;

    [SerializeField] private ScoreUI m_scoreUI = null;
    [SerializeField] private GameOverUI m_grpGameOver = null;

    [SerializeField] private Player m_player = null;
    [SerializeField] private EnemySpawner m_enemySpawner = null;

    private int m_currentScore = 0;
    private int m_currentLifeCount = MAX_LIFE_COUNT;

    private SetLifeEvent m_setLifeEvent = null;
    public SetLifeEvent setLifeEvent
    {
        get
        {
            if (null == this.m_setLifeEvent)
            {
                this.m_setLifeEvent = new SetLifeEvent();
            }

            return this.m_setLifeEvent;
        }
    }

    //======================================================================================================================================================================================================================

    #region Monobehaviour

    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            m_instance = this;
        }
    }

    private void OnEnable()
    {
        this.setLifeEvent.AddListener(this.SetLifeEvent);
    }

    private void OnDisable()
    {
        this.setLifeEvent.RemoveListener(this.SetLifeEvent);
    }

    #endregion Monobehaviour

    //======================================================================================================================================================================================================================

    #region Events

    private void SetLifeEvent(int lifeCount)
    {
        this.m_currentLifeCount = lifeCount;

        if (this.m_currentLifeCount == 0)
        {
            this.EndGame();
        }
    }

    #endregion Events

    //======================================================================================================================================================================================================================

    #region Functions

    private void EndGame()
    {
        this.m_grpGameOver.gameObject.SetActive(true);
        this.m_player.gameObject.SetActive(false);
        this.m_enemySpawner.gameObject.SetActive(false);
    }

    public void SetScore(int score)
    {
        this.m_currentScore = score;
        this.m_scoreUI.SetScoreText(this.m_currentScore);
    }

    #endregion Functions

    //======================================================================================================================================================================================================================

    #region Getters

    public int GetCurrentScore()
    {
        return this.m_currentScore;
    }

    public int GetCurrentLifeCount()
    {
        return this.m_currentLifeCount;
    }

    #endregion Getters

    //======================================================================================================================================================================================================================
}