using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] m_enemiesType = null;
    [SerializeField] private Vector2 m_screenBoundPercentage = new Vector2(0.95f, 1.5f); // can do a gizmo to draw bound, use to adjust bound of player space
    [SerializeField] private float m_spawnInterval = 0.25f;
    [SerializeField] private float m_simultaneousSpawnCount = 1f;

    private Vector2 m_spawnerScreenBound = Vector2.zero;
    private float m_currentTimer = 0f;
    
    //======================================================================================================================================================================================================================

    #region Monobehaviour

    private void Awake()
    {
        float screenBoundX = Screen.width * this.m_screenBoundPercentage.x;
        float screenBoundY = Screen.height * this.m_screenBoundPercentage.y;
        Vector3 adjustedScreenBound = new Vector3(screenBoundX, screenBoundY, 0f);

        this.m_spawnerScreenBound = Camera.main.ScreenToWorldPoint(adjustedScreenBound);
    }

    private void Update()
    {
        if (this.m_currentTimer > 0f)
        {
            this.m_currentTimer -= Time.deltaTime;
        }
        else
        {
            this.m_currentTimer = this.m_spawnInterval;
            this.Spawn(this.m_simultaneousSpawnCount);
        }
    }

    #endregion Monobehaviour

    //======================================================================================================================================================================================================================

    #region Function

    private void Spawn(float simultaneousSpawnCount)
    {
        float spawnPosX = Random.Range(-this.m_spawnerScreenBound.x, this.m_spawnerScreenBound.x);
        float spawnPosY = this.m_spawnerScreenBound.y;
        Vector2 spawnPos = new Vector2(spawnPosX, spawnPosY);

        Enemy chosenEnemyType = this.m_enemiesType[Random.Range(0, this.m_enemiesType.Length)];

        Instantiate(chosenEnemyType.gameObject, spawnPos, Quaternion.identity);
    }

    #endregion Function

    //======================================================================================================================================================================================================================
}