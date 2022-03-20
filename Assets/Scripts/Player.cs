using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int ENEMY_LAYER = 6;

    [SerializeField] private Vector2 m_screenBoundPercentage = new Vector2(0.95f, 0.95f); // can do a gizmo to draw bound, use to adjust bound of player space
    [SerializeField] private GameObject m_selfHitVFX = null;

    private Vector2 m_playerScreenBound = Vector2.zero;

    //======================================================================================================================================================================================================================

    #region Monobehaviour

    private void Awake()
    {
        float screenBoundX = Screen.width * this.m_screenBoundPercentage.x;
        float screenBoundY = Screen.height * this.m_screenBoundPercentage.y;
        Vector3 adjustedScreenBound = new Vector3(screenBoundX, screenBoundY, 0f);

        this.m_playerScreenBound = Camera.main.ScreenToWorldPoint(adjustedScreenBound);
    }

    private void Update()
    {
        this.ClampPositionWithinScreen();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == ENEMY_LAYER)
        {
            Destroy(collision.gameObject);

            Instantiate(this.m_selfHitVFX, this.transform.position, Quaternion.identity);

            int currentLifeCount = GameHandler.Instance.GetCurrentLifeCount();
            GameHandler.Instance.setLifeEvent.Invoke(--currentLifeCount);
        }
    }

    #endregion Monobehaviour

    //======================================================================================================================================================================================================================

    #region Function

    private void ClampPositionWithinScreen()
    {
        float clampedBoundX = Mathf.Clamp(this.transform.position.x, -this.m_playerScreenBound.x, this.m_playerScreenBound.x);
        float clampedBoundY = Mathf.Clamp(this.transform.position.y, -this.m_playerScreenBound.y, this.m_playerScreenBound.y);

        this.transform.position = new Vector2(clampedBoundX, clampedBoundY);
    }

    #endregion Function

    //======================================================================================================================================================================================================================
}